using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MikkelDepoTalep
{
    public partial class mainForm : Form
    {
        public string name, username;
        public double birim_fiyat, toplam_fiyat;
        int talepSınır;
        Database mikkelDB = new Database();
        ResourceManager rManager = new ResourceManager("MikkelDepoTalep.Properties.Resources", Assembly.GetExecutingAssembly());

        public mainForm(string _name, string _username)
        {
            InitializeComponent();
            name = _name;
            username = _username;
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            musteriEkleSilGuncelleForm mESGF = new musteriEkleSilGuncelleForm();
            mESGF.ShowDialog();
        }

        private void btnMarka_Click(object sender, EventArgs e)
        {
            markategoriEkleSilForm mESF = new markategoriEkleSilForm("Marka", "marka");
            mESF.ShowDialog();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            markategoriEkleSilForm mESF = new markategoriEkleSilForm("Kategori", "kategori");
            mESF.ShowDialog();
        }

        private void btnTedarikciEkle_Click(object sender, EventArgs e)
        {
            tedarikciEkleSilGuncelle tESGF = new tedarikciEkleSilGuncelle();
            tESGF.ShowDialog();
        }

        private void btnMusteriListele_Click(object sender, EventArgs e)
        {
            listele lst = new listele("Müşteri", "musteri", String.Empty);
            lst.ShowDialog();
        }

        private void btnTedarikciListele_Click(object sender, EventArgs e)
        {
            listele lst = new listele("Tedarikçi", "tedarikci", String.Empty);
            lst.ShowDialog();
        }

        private void btnUrunListele_Click(object sender, EventArgs e)
        {
            listele lst = new listele("Ürün", "urun", String.Empty);
            lst.ShowDialog();
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            urunEkleSilGuncelleForm uESGF = new urunEkleSilGuncelleForm();
            uESGF.ShowDialog();
        }

        private void btnDepoListele_Click(object sender, EventArgs e)
        {
            listele lst = new listele("Depo", "depo", String.Empty);
            lst.ShowDialog();
        }

        private void btnDepoEkleSilGuncelle_Click(object sender, EventArgs e)
        {
            depoEkleSilGuncelleForm dESGF = new depoEkleSilGuncelleForm();
            dESGF.ShowDialog();
        }

        private void txtBarkod_TextChanged(object sender, EventArgs e)
        {
            txtUrunAdi.Text = mikkelDB.GetValue("SELECT * FROM urun WHERE barkod='"+txtBarkod.Text+"'", "name");
            if (!String.IsNullOrEmpty(txtUrunAdi.Text))
            {
                string val = mikkelDB.GetValue("SELECT * FROM depo WHERE barkod='" + txtBarkod.Text + "'", "adet");
                if (!String.IsNullOrEmpty(val))//ürün depoda var mı?
                {
                    adetSayar.Maximum = Convert.ToInt32(val);
                    adetSayar.Minimum = 1;
                }                    
                else adetSayar.Maximum = 0;
            } 
        }

        private void txtMusteriTel_TextChanged(object sender, EventArgs e)
        {
            txtMusteriAdi.Text = mikkelDB.GetValue("SELECT * FROM musteri WHERE phone='"+txtMusteriTel.Text+"'", "name");
        }


        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtMusteriAdi.Text) && !String.IsNullOrEmpty(txtUrunAdi.Text) && adetSayar.Value != 0)
            {
                //+musteri_tel, +musteri_adi, +urun_barkod, +urun_adi, +adet, birim_fiyat, toplam_fiyat, +tarih
                birim_fiyat = Convert.ToDouble(mikkelDB.GetValue("SELECT * FROM urun WHERE barkod='" + txtBarkod.Text + "'", "fiyat"));
                toplam_fiyat = (float)adetSayar.Value * birim_fiyat;

                bool varMi = mikkelDB.IsExist("SELECT * FROM sepet WHERE musteri_tel='" + txtMusteriTel.Text + "' AND urun_barkod='" + txtBarkod.Text + "'", "adet");

                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command = mikkelDB.connection.CreateCommand();
                    if (varMi)//sepette var
                    {
                        mikkelDB.command.CommandText = "UPDATE sepet SET adet = adet + @adet, toplam_fiyat = toplam_fiyat + @toplam_fiyat WHERE musteri_tel = @musteri_tel AND urun_barkod = @urun_barkod";
                        mikkelDB.command.Parameters.AddWithValue("@adet", adetSayar.Value);
                        mikkelDB.command.Parameters.AddWithValue("@toplam_fiyat", toplam_fiyat);
                        mikkelDB.command.Parameters.AddWithValue("@musteri_tel", txtMusteriTel.Text);
                        mikkelDB.command.Parameters.AddWithValue("@urun_barkod", txtBarkod.Text);
                    }
                    else
                    {
                        mikkelDB.command.CommandText = "INSERT INTO sepet (musteri_tel, musteri_adi, urun_barkod, urun_adi, adet, birim_fiyat, toplam_fiyat, tarih) VALUES (@musteri_tel, @musteri_adi, @urun_barkod, @urun_adi, @adet, @birim_fiyat, @toplam_fiyat, @tarih)";
                        mikkelDB.command.Parameters.AddWithValue("@musteri_tel", txtMusteriTel.Text);
                        mikkelDB.command.Parameters.AddWithValue("@musteri_adi", txtMusteriAdi.Text);
                        mikkelDB.command.Parameters.AddWithValue("@urun_barkod", txtBarkod.Text);
                        mikkelDB.command.Parameters.AddWithValue("@urun_adi", txtUrunAdi.Text);
                        mikkelDB.command.Parameters.AddWithValue("@adet", adetSayar.Value);
                        mikkelDB.command.Parameters.AddWithValue("@birim_fiyat", birim_fiyat);
                        mikkelDB.command.Parameters.AddWithValue("@toplam_fiyat", toplam_fiyat);
                        mikkelDB.command.Parameters.AddWithValue("@tarih", DateTime.Now.Year+"-"+DateTime.Now.Month+"-"+DateTime.Now.Day);//dateValue.ToString("yyyy-MM-dd
                    }
                    mikkelDB.command.ExecuteNonQuery();

                    mikkelDB.LoadDB();//depoyu güncelle veya sil
                    mikkelDB.command = mikkelDB.connection.CreateCommand();
                    if (adetSayar.Value >= adetSayar.Maximum)
                    {
                        mikkelDB.command.CommandText = "DELETE FROM depo WHERE barkod=@barkod";
                        mikkelDB.command.Parameters.AddWithValue("@barkod", txtBarkod.Text);
                        mikkelDB.command.ExecuteNonQuery();
                    }
                    else
                    {
                        mikkelDB.command.CommandText = "UPDATE depo SET adet = adet - @adet WHERE barkod=@barkod";
                        mikkelDB.command.Parameters.AddWithValue("@adet", adetSayar.Value);
                        mikkelDB.command.Parameters.AddWithValue("@barkod", txtBarkod.Text);
                        mikkelDB.command.ExecuteNonQuery();
                    }

                    txtBarkod.Text = txtUrunAdi.Text = String.Empty;
                    adetSayar.Value = 1;

                    sepetGuncelle();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ürün sepete eklenirken bir hata oluştu.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız veya ürün adedini 0 dan farklı seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            userNameLabel.Text = name;
            tarihLabel.Text = DateTime.Now.ToString();
            talepSınır = Properties.Settings.Default.talepSınır;
            sepetGuncelle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string barkod = sepet.Rows[sepet.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string adet = sepet.Rows[sepet.CurrentCell.RowIndex].Cells[4].Value.ToString();
            string musteri_tel = sepet.Rows[sepet.CurrentCell.RowIndex].Cells[0].Value.ToString();
            sepetSecileniSil(barkod, adet, musteri_tel);
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            int n = sepet.RowCount;
            for (int i = 0; i < n; i++)
            {
                string barkod = sepet.Rows[0].Cells[2].Value.ToString();
                string adet = sepet.Rows[0].Cells[4].Value.ToString();
                string musteri_tel = sepet.Rows[0].Cells[0].Value.ToString();
                sepetSecileniSil(barkod, adet, musteri_tel);
            }
            sepetGuncelle();
        }

        void sepetSecileniSil(string _barkod, string _adet, string _musteri_tel)
        {
            bool varMi = mikkelDB.IsExist("SELECT * FROM depo WHERE barkod = " + _barkod, "barkod");
            bool sil = mikkelDB.Delete("DELETE FROM sepet WHERE urun_barkod = '" + _barkod + "' AND musteri_tel = '" + _musteri_tel + "'");
            if (varMi)//depoda varsa sepetten sil -> depodakini güncelle
            {                
                if (sil)
                {
                    sepetSelectedRowDelete();

                    mikkelDB.LoadDB();
                    mikkelDB.command = mikkelDB.connection.CreateCommand();
                    mikkelDB.command.CommandText = "UPDATE depo SET adet = adet + @adet WHERE barkod = @barkod";
                    mikkelDB.command.Parameters.AddWithValue("@adet", _adet);
                    mikkelDB.command.Parameters.AddWithValue("@barkod", _barkod);
                    mikkelDB.command.ExecuteNonQuery();
                    sepetGuncelle();
                }
            }
            else//depoda da yoksa sepetten sil -> depoya ekle
            {
                if (sil)
                {
                    sepetSelectedRowDelete();

                    mikkelDB.LoadDB();
                    mikkelDB.command = mikkelDB.connection.CreateCommand();
                    mikkelDB.command.CommandText = "INSERT INTO depo (barkod, adet) VALUES (@barkod, @adet)";
                    mikkelDB.command.Parameters.AddWithValue("@adet", _adet);
                    mikkelDB.command.Parameters.AddWithValue("@barkod", _barkod);
                    mikkelDB.command.ExecuteNonQuery();
                    sepetGuncelle();
                }
            }
        }

        void sepetSelectedRowDelete()
        {
            foreach (DataGridViewRow row in sepet.SelectedRows)
                sepet.Rows.RemoveAt(row.Index);
        }

        private void btnSatisBugun_Click(object sender, EventArgs e)
        {
            listele lst = new listele(DateTime.Now.ToShortDateString() + " (Bugün) Tarihli Satış Listesi", "satis", "tarih = '" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day+"'");
            lst.ShowDialog();
        }

        private void btnTarihSec_Click(object sender, EventArgs e)
        {
            string tarih = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day;
            listele lst = new listele(tarih + " | Tarihli Satış Listesi", "satis", "tarih = '" + tarih + "'");
            lst.ShowDialog();
        }

        private void btnTalepListele_Click(object sender, EventArgs e)
        {
            listele lst = new listele("Talep", "talep", String.Empty);
            lst.ShowDialog();
        }

        private void btnTalepEkle_Click(object sender, EventArgs e)
        {
            talepEkleSilGuncelleForm tESGF = new talepEkleSilGuncelleForm(username);
            tESGF.ShowDialog();
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ayarlar set = new ayarlar();
            set.ShowDialog();
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            int n = sepet.RowCount;
            for (int i = 0; i < n; i++)
            {
                mikkelDB.LoadDB();
                mikkelDB.command = mikkelDB.connection.CreateCommand();
                mikkelDB.command.CommandText = "INSERT INTO satis (admin_username, musteri_tel, urun_no, adet, toplam_fiyat, tarih) VALUES (@admin_username, @musteri_tel, @urun_no, @adet, @toplam_fiyat, @tarih)";
                mikkelDB.command.Parameters.AddWithValue("@admin_username", username);
                mikkelDB.command.Parameters.AddWithValue("@musteri_tel", sepet.Rows[i].Cells[0].Value);
                mikkelDB.command.Parameters.AddWithValue("@urun_no", sepet.Rows[i].Cells[2].Value);
                mikkelDB.command.Parameters.AddWithValue("@adet", sepet.Rows[i].Cells[5].Value);
                mikkelDB.command.Parameters.AddWithValue("@toplam_fiyat", sepet.Rows[i].Cells[6].Value);
                mikkelDB.command.Parameters.AddWithValue("@tarih", DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
                mikkelDB.command.ExecuteNonQuery();

                /*int urunAdet = Convert.ToInt32(mikkelDB.GetValue("SELECT * FROM depo WHERE barkod='" + sepet.Rows[i].Cells[2].Value + "'", "adet"));
                if(urunAdet <= Properties.Settings.Default.talepSınır)
                {
                    string tedTel = "";//Halledilecek iş var. Kontrol edilecek ürünün

                    mikkelDB.LoadDB();
                    mikkelDB.command = mikkelDB.connection.CreateCommand();
                    mikkelDB.command.CommandText = "INSERT INTO talep (admin_username, tedarikci_tel, urun_barkod, adet, teslim_tarihi) VALUES ('"+username+"', '"+tedTel+"', '"+ sepet.Rows[i].Cells[2].Value + "', "+Properties.Settings.Default.talepMiktar+", '"+ Convert.ToString(DateTime.Now.AddDays(Properties.Settings.Default.teslimGun).ToShortDateString().Replace(".", "-")) + ")";
                    mikkelDB.command.ExecuteNonQuery();
                }*/
            }



            mikkelDB.Truncate("sepet");

            sepetGuncelle();
        }

        void sepetGuncelle()
        {
            mikkelDB.LoadDB();
            mikkelDB.adapter = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM sepet", mikkelDB.connection);
            DataTable dt = new DataTable();
            mikkelDB.adapter.Fill(dt);
            sepet.DataSource = dt;
            sepet.Columns[0].HeaderText = "Müşteri Telefonu";
            sepet.Columns[1].HeaderText = "Müşteri Adi";
            sepet.Columns[2].HeaderText = "Barkod";
            sepet.Columns[3].HeaderText = "Ürün Adi";
            sepet.Columns[4].HeaderText = "Adet";
            sepet.Columns[5].HeaderText = "Birim Fiyat";
            sepet.Columns[6].HeaderText = "Toplam Fiyat";
            sepet.Columns[7].HeaderText = "Tarih";

            if (sepet.RowCount > 0)
            {
                int n = sepet.RowCount; double top = 0;
                for (int i = 0; i < n; i++)
                    top += Convert.ToDouble(sepet.Rows[i].Cells[6].Value);
                lblToplamSonuc.Text = top.ToString() + " TL";

                lblToplam.Visible = lblToplamSonuc.Visible = btnSil.Enabled = btnTemizle.Enabled = btnSatis.Enabled = true;
            }
            else
            {
                lblToplam.Visible = lblToplamSonuc.Visible = btnSil.Enabled = btnTemizle.Enabled = btnSatis.Enabled = false;
            }
        }
    }
}
