using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MikkelDepoTalep
{
    public partial class urunEkleSilGuncelleForm : Form
    {

        Database mikkelDB = new Database();

        public urunEkleSilGuncelleForm()
        {
            InitializeComponent();
        }

        private void urunEkleSilGuncelleForm_Load(object sender, EventArgs e)
        {
            
            mikkelDB.ComboBoxLoader("kategori", "kategori", cmbKategori);
            mikkelDB.ComboBoxLoader("marka", "marka", cmbKategori);

            mikkelDB.LoadDB();
            mikkelDB.command.CommandText = "SELECT * FROM marka";
            mikkelDB.reader = mikkelDB.command.ExecuteReader();
            while (mikkelDB.reader.Read())
                cmbMarka.Items.Add(mikkelDB.reader["marka"].ToString());

            cmbKategori.SelectedIndex = 0;
            cmbMarka.SelectedIndex = 0;

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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtBarkod.Text) && !String.IsNullOrEmpty(txtAdi.Text) && !String.IsNullOrEmpty(txtFiyat.Text))
            {
                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "SELECT * FROM urun WHERE barkod=@barkod";
                    mikkelDB.command.Parameters.AddWithValue("@barkod", txtBarkod.Text);
                    mikkelDB.reader = mikkelDB.command.ExecuteReader();

                    if (!mikkelDB.reader.Read())
                    {
                        mikkelDB.LoadDB();
                        mikkelDB.command.CommandText = "INSERT INTO urun (barkod, name, kategori_no, marka_no, fiyat) VALUES (@barkod, @name, @kategori, @marka, @fiyat)";
                        mikkelDB.command.Parameters.AddWithValue("@barkod", txtBarkod.Text);
                        mikkelDB.command.Parameters.AddWithValue("@name", txtAdi.Text);
                        mikkelDB.command.Parameters.AddWithValue("@kategori", cmbKategori.SelectedItem.ToString());
                        mikkelDB.command.Parameters.AddWithValue("@marka", cmbMarka.SelectedItem.ToString());
                        mikkelDB.command.Parameters.AddWithValue("@fiyat", Convert.ToDouble(txtFiyat.Text));
                        mikkelDB.command.ExecuteNonQuery();

                        MessageBox.Show("Ürün kayıt işlemi başarılı!", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Var olan bir barkodlu ürün eklenmeye çalışıldı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Hata; \n" + error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen boş kutucuk bırakmayınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBarkod_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBarkod.Text))
            {
                mikkelDB.LoadDB();
                mikkelDB.command.CommandText = "SELECT * FROM urun WHERE barkod=@barkod";
                mikkelDB.command.Parameters.AddWithValue("@barkod", txtBarkod.Text);
                mikkelDB.reader = mikkelDB.command.ExecuteReader();

                if (mikkelDB.reader.Read())
                {
                    txtAdi.Text = mikkelDB.reader["name"].ToString();
                    cmbKategori.SelectedItem = mikkelDB.reader["kategori_no"].ToString();
                    cmbMarka.SelectedItem = mikkelDB.reader["marka_no"].ToString();
                    txtFiyat.Text = mikkelDB.reader["fiyat"].ToString();

                    btnKaydet.Enabled = false;
                    btnSil.Enabled = true;
                    btnGuncelle.Enabled = true;
                }
                else
                {
                    txtAdi.Text = txtFiyat.Text = "";
                    cmbKategori.SelectedIndex = 0;
                    cmbMarka.SelectedIndex = 0;

                    btnKaydet.Enabled = true;
                    btnSil.Enabled = false;
                    btnGuncelle.Enabled = false;
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBarkod.Text))
            {
                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "DELETE FROM urun WHERE barkod=@barkod";
                    mikkelDB.command.Parameters.AddWithValue("@barkod", txtBarkod.Text);
                    mikkelDB.command.ExecuteNonQuery();

                    MessageBox.Show("Silme işlemi başarıyla gerçekleşti!", "Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Hata:\n" + error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen kutucuğu boş bırakmayınız!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAdi.Text) && !String.IsNullOrEmpty(txtFiyat.Text))
            {
                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "UPDATE urun SET name=@name, kategori_no=@kategori, marka_no=@marka, fiyat=@fiyat WHERE barkod=@barkod";
                    mikkelDB.command.Parameters.AddWithValue("@name", txtAdi.Text);
                    mikkelDB.command.Parameters.AddWithValue("@kategori", cmbKategori.SelectedItem.ToString());
                    mikkelDB.command.Parameters.AddWithValue("@marka", cmbMarka.SelectedItem.ToString());
                    mikkelDB.command.Parameters.AddWithValue("@fiyat", Convert.ToDouble(txtFiyat.Text));
                    mikkelDB.command.Parameters.AddWithValue("@barkod", txtBarkod.Text);
                    mikkelDB.command.ExecuteNonQuery();

                    MessageBox.Show("Ürün başarıyla güncellendi!", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Güncelleme işlemi şu sebepten gerçekleşemedi;\n" + error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Güncelleme işleminin gerçekleşebilmesi için boş alan bırakmamalısınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
