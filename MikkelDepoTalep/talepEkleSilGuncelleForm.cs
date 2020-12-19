using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MikkelDepoTalep
{
    public partial class talepEkleSilGuncelleForm : Form
    {
        Database mikkelDB = new Database();
        string adet, tarih, adminUserName, __tel, __barkod;

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            if (dateTeslimTarih.Value > DateTime.Now && !String.IsNullOrEmpty(txtTedarikciShow.Text) & !String.IsNullOrEmpty(txtBarkodShow.Text))
            {
                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command = mikkelDB.connection.CreateCommand();
                    mikkelDB.command.CommandText = "UPDATE talep SET adet=" + numAdet.Value + ", teslim_tarihi='" + dateTeslimTarih.Value.Year + "-" + dateTeslimTarih.Value.Month + "-" + dateTeslimTarih.Value.Day + "' WHERE tedarikci_tel='" + txtTedarikciTel.Text + "' AND urun_barkod='" + txtUrunBarkod.Text + "'";
                    mikkelDB.command.ExecuteNonQuery();

                    MessageBox.Show("Güncelleme işlemi başarılı!", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Güncelleme işlemi gerçekleştirilirken bir hata ile karşılaşıldı!\nHata;\n" + error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Bu uyarının sebepleri;\n* Bugün haricinde ileri bir tarih seçiniz!\n* Geçerli bir tedarikci ve urun kodu giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(mikkelDB.Delete("DELETE FROM talep WHERE tedarikci_tel = '" + __tel+  "' AND urun_barkod='" + __barkod + "'") && !String.IsNullOrEmpty(txtTedarikciShow.Text) & !String.IsNullOrEmpty(txtBarkodShow.Text))
            {
                MessageBox.Show("Talep başarıyla silindi!", "Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Silme işlemi gerçekleşirken bir hata ile karşılaşıldı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public talepEkleSilGuncelleForm(string _adminUserName)
        {
            InitializeComponent();
            adminUserName = _adminUserName;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(dateTeslimTarih.Value > DateTime.Now && !String.IsNullOrEmpty(txtTedarikciShow.Text) & !String.IsNullOrEmpty(txtBarkodShow.Text))
            {
                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command = mikkelDB.connection.CreateCommand();
                    mikkelDB.command.CommandText = "INSERT INTO talep (admin_username, tedarikci_tel, urun_barkod, adet, teslim_tarihi) VALUES (@admin_username, @tedarikci_tel, @urun_barkod, @adet, @teslim_tarihi)";
                    mikkelDB.command.Parameters.AddWithValue("@admin_username", adminUserName);
                    mikkelDB.command.Parameters.AddWithValue("@tedarikci_tel", txtTedarikciTel.Text);
                    mikkelDB.command.Parameters.AddWithValue("@urun_barkod", txtUrunBarkod.Text);
                    mikkelDB.command.Parameters.AddWithValue("@adet", numAdet.Value);
                    mikkelDB.command.Parameters.AddWithValue("@teslim_tarihi", dateTeslimTarih.Value.Year + "-" + dateTeslimTarih.Value.Month + "-" + dateTeslimTarih.Value.Day);
                    mikkelDB.command.ExecuteNonQuery();

                    MessageBox.Show("Talep kaydı başarılı!", "KAYIT BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Hata ile karşılaşıldı!\nHata;\n" + error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bu uyarının sebepleri;\n* Bugün haricinde ileri bir tarih seçiniz!\n* Geçerli bir tedarikci ve urun kodu giriniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            //Otomatik doldurma işlemi (adet - tarih)
            if(!String.IsNullOrEmpty(txtTedarikciTel.Text) && !String.IsNullOrEmpty(txtUrunBarkod.Text))
            {
                adet = mikkelDB.GetValue("SELECT * FROM talep WHERE tedarikci_tel = '" + txtTedarikciTel.Text + "' AND urun_barkod = '" + txtUrunBarkod.Text + "'", "adet");
                tarih = mikkelDB.GetValue("SELECT * FROM talep WHERE tedarikci_tel = '" + txtTedarikciTel.Text + "' AND urun_barkod = '" + txtUrunBarkod.Text + "'", "teslim_tarihi");
                if (!String.IsNullOrEmpty(adet) && !String.IsNullOrEmpty(tarih))
                {
                    btnKaydet.Enabled = false;
                    btnGüncelle.Enabled = btnSil.Enabled = true;
                    numAdet.Value = int.Parse(adet);
                    dateTeslimTarih.Value = Convert.ToDateTime(tarih);
                }
                else
                {
                    btnKaydet.Enabled = true;
                    btnGüncelle.Enabled = btnSil.Enabled = false;
                }
            }

            //Tedarikci İsmi Göster (txtTedarikciShow)
            if (!String.IsNullOrEmpty(txtTedarikciTel.Text))
            {
                txtTedarikciShow.Text = mikkelDB.GetValue("SELECT * FROM tedarikci WHERE phone = '" + txtTedarikciTel.Text + "'", "name");
                __tel = txtTedarikciTel.Text;
            }

            //Urun İsmi Göster (txtBarkodShow)
            if (!String.IsNullOrEmpty(txtUrunBarkod.Text))
            {
                txtBarkodShow.Text = mikkelDB.GetValue("SELECT * FROM urun WHERE barkod = '" + txtUrunBarkod.Text + "'", "name");
                __barkod = txtUrunBarkod.Text;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}