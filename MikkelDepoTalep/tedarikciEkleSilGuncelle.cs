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
    public partial class tedarikciEkleSilGuncelle : Form
    {
        public tedarikciEkleSilGuncelle()
        {
            InitializeComponent();
        }

        Database mikkelDB = new Database();

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
            if (!String.IsNullOrEmpty(txtAdi.Text) && !String.IsNullOrEmpty(txtSoyadi.Text) && !String.IsNullOrEmpty(txtTelefon.Text) && !String.IsNullOrEmpty(txtEposta.Text))
            {
                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "INSERT INTO tedarikci (name, surname, phone, mail) VALUES (@adi, @soyadi, @telefon, @mail)";
                    mikkelDB.command.Parameters.AddWithValue("@adi", txtAdi.Text);
                    mikkelDB.command.Parameters.AddWithValue("@soyadi", txtSoyadi.Text);
                    mikkelDB.command.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                    mikkelDB.command.Parameters.AddWithValue("@mail", txtEposta.Text);
                    mikkelDB.command.ExecuteNonQuery();

                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "INSERT INTO tedarikci_mk (tedarikci_tel, kategori, marka) VALUES (@tel, @kategori, @marka)";
                    mikkelDB.command.Parameters.AddWithValue("@kategori", cmbKategori.Text);
                    mikkelDB.command.Parameters.AddWithValue("@marka", cmbMarka.Text);
                    mikkelDB.command.Parameters.AddWithValue("@tel", txtTelefon.Text);
                    mikkelDB.command.ExecuteNonQuery();

                    MessageBox.Show("Kaydınız başarıyla tamamlandı!", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Kayıt tamamlanamadı! Hata;\n" + error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hatanın olası sebepleri;\n* Kutuların boş bırakılması\n* Telefon kısmına harf girilmesi\n* Başka bir tedarikcinin tedarik ettiği kategori ve markayı seçmeniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTelefon.Text))
            {
                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "SELECT * FROM tedarikci WHERE phone = @telefon";
                    mikkelDB.command.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                    mikkelDB.reader = mikkelDB.command.ExecuteReader();
                    if (mikkelDB.reader.Read())
                    {
                        string isim = mikkelDB.reader["name"].ToString() + " " + mikkelDB.reader["surname"].ToString();

                        mikkelDB.Delete("DELETE FROM tedarikci WHERE phone='" + txtTelefon.Text + "'");
                        mikkelDB.Delete("DELETE FROM tedarikci_mk WHERE tedarikci_tel='" + txtTelefon.Text + "'");

                        MessageBox.Show(isim + " isimli kişi başarıyla silindi!", "Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(txtTelefon.Text + " telefon numaralı birisi kayıtlı değil!", "Silme Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Silme işlemi şu sebepten gerçekleşemedi;\n" + error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Silme işleminin gerçekleşebilmesi için geçerli bir telefon numarası girmelisiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTelefon.Text))
            {
                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "SELECT * FROM tedarikci WHERE phone = @telefon";
                    mikkelDB.command.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                    mikkelDB.reader = mikkelDB.command.ExecuteReader();
                    if (mikkelDB.reader.Read())
                    {
                        txtAdi.Text = mikkelDB.reader["name"].ToString();
                        txtSoyadi.Text = mikkelDB.reader["surname"].ToString();
                        txtEposta.Text = mikkelDB.reader["mail"].ToString();
                        
                        cmbKategori.SelectedIndex = cmbKategori.Items.IndexOf(mikkelDB.GetValue("SELECT * FROM tedarikci_mk WHERE tedarikci_tel='" + txtTelefon.Text + "'", "kategori"));
                        cmbMarka.SelectedIndex = cmbMarka.Items.IndexOf(mikkelDB.GetValue("SELECT * FROM tedarikci_mk WHERE tedarikci_tel='" + txtTelefon.Text + "'", "marka"));

                        btnKaydet.Enabled = false;
                        btnGuncelle.Enabled = true;
                        btnSil.Enabled = true;
                    }
                    else
                    {
                        txtAdi.Text = txtSoyadi.Text = txtEposta.Text = "";

                        btnSil.Enabled = false;
                        btnKaydet.Enabled = true;
                        btnGuncelle.Enabled = false;
                    }
                }
                catch (Exception)
                {
                    
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAdi.Text) && !String.IsNullOrEmpty(txtSoyadi.Text) && !String.IsNullOrEmpty(txtTelefon.Text) && !String.IsNullOrEmpty(txtEposta.Text))
            {
                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "UPDATE tedarikci SET name=@adi, surname=@soyadi, mail=@mail WHERE phone = @telefon";
                    mikkelDB.command.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                    mikkelDB.command.Parameters.AddWithValue("@adi", txtAdi.Text);
                    mikkelDB.command.Parameters.AddWithValue("@soyadi", txtSoyadi.Text);
                    mikkelDB.command.Parameters.AddWithValue("@mail", txtEposta.Text);
                    mikkelDB.command.ExecuteNonQuery();

                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "UPDATE tedarikci_mk SET kategori=@kategori, marka=@marka WHERE phone = @telefon";
                    mikkelDB.command.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                    mikkelDB.command.Parameters.AddWithValue("@kategori", cmbKategori.Text);
                    mikkelDB.command.Parameters.AddWithValue("@marka", cmbMarka.Text);
                    mikkelDB.command.ExecuteNonQuery();

                    MessageBox.Show(txtAdi.Text + " " + txtSoyadi.Text + " isimli kişi başarıyla güncellendi!", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void tedarikciEkleSilGuncelle_Load(object sender, EventArgs e)
        {
            mikkelDB.ComboBoxLoader("kategori", "kategori", cmbKategori);
            mikkelDB.ComboBoxLoader("marka", "marka", cmbMarka);

            cmbKategori.SelectedIndex = 0;
            cmbMarka.SelectedIndex = 0;
        }
    }
}
