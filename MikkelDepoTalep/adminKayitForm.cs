using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MikkelDepoTalep
{
    public partial class adminKayitForm : Form
    {
        string username;

        public adminKayitForm(string _username)
        {
            InitializeComponent();
            username = _username;
        }

        Database mikkelDB = new Database();

        private void adminKayitForm_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(username))
            {
                usernameText.Text = username;
                usernameText.Enabled = false;

                this.Text = "Admin Güncelleme Paneli";
                label2.Text = "Admin Güncelleme Formu";

            }
            Fill();
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

        private void kayitButton_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(usernameText.Text) && !String.IsNullOrEmpty(nameText.Text) && !String.IsNullOrEmpty(surnameText.Text) && !String.IsNullOrEmpty(passText.Text))
            {
                mikkelDB.LoadDB();
                if (mikkelDB.state)
                {
                    mikkelDB.command.CommandText = "INSERT INTO admin (username, name, surname, password) VALUES (@usernameText, @nameText, @surnameText, @passwordText)";
                    mikkelDB.command.Parameters.AddWithValue("@usernameText", usernameText.Text);
                    mikkelDB.command.Parameters.AddWithValue("@nameText", nameText.Text);
                    mikkelDB.command.Parameters.AddWithValue("@surnameText", surnameText.Text);
                    mikkelDB.command.Parameters.AddWithValue("@passwordText", passText.Text);
                    try
                    {
                        mikkelDB.command.ExecuteNonQuery();
                        MessageBox.Show("Kaydınız başarıyla oluşturulmuştur!", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Kayıt oluşturulurken bir hata ile karşılaşıldı.\nTahmini hata: Var olan bir kullanıcı adını giriyor olmanız.\nHata mesajı;\n" + error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Bu hatayı almanızın olası sebepleri aşağıda listelenmiştir;\n* Eğer boş bıraktıysanız lütfen gerekli alanları doldurarak tekrar deneyiniz.\n* Var olan bir kullanıcı adını tekrar eklmeye çalışmayınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        void Fill()
        {
            bool varMi = mikkelDB.IsExist("SELECT * FROM admin WHERE username = '" + usernameText.Text + "'", "username");
            if (varMi && !String.IsNullOrEmpty(username))
            {
                kayitButton.Enabled = false;
                btnSil.Enabled = btnGuncelle.Enabled = true;

                nameText.Text = mikkelDB.GetValue("SELECT * FROM admin WHERE username='" + usernameText.Text + "'", "name");
                surnameText.Text = mikkelDB.GetValue("SELECT * FROM admin WHERE username='" + usernameText.Text + "'", "surname");
                passText.Text = mikkelDB.GetValue("SELECT * FROM admin WHERE username='" + usernameText.Text + "'", "password");
            }
            else
            {
                kayitButton.Enabled = true;
                btnSil.Enabled = btnGuncelle.Enabled = false;
            }
        }

        private void usernameText_TextChanged(object sender, EventArgs e)
        {
            Fill();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                mikkelDB.LoadDB();
                mikkelDB.command.CommandText = "DELETE FROM admin WHERE username = @username AND password = @password";
                mikkelDB.command.Parameters.AddWithValue("@username", usernameText.Text);
                mikkelDB.command.Parameters.AddWithValue("@password", passText.Text);
                mikkelDB.reader = mikkelDB.command.ExecuteReader();
                MessageBox.Show("Silme işlemi başarılı!", "Admin Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            catch (Exception error)
            {
                MessageBox.Show("Silme işlemi gerçekleştirilemedi! Hatanın sebebi;\n" + error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(nameText.Text) && !String.IsNullOrEmpty(surnameText.Text) && !String.IsNullOrEmpty(passText.Text))
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "UPDATE admin SET name=@name, surname=@surname, password=@password WHERE username=@username";
                    mikkelDB.command.Parameters.AddWithValue("@name", nameText.Text);
                    mikkelDB.command.Parameters.AddWithValue("@surname", surnameText.Text);
                    mikkelDB.command.Parameters.AddWithValue("@password", passText.Text);
                    mikkelDB.command.Parameters.AddWithValue("@username", usernameText.Text);
                    mikkelDB.command.ExecuteNonQuery();
                    MessageBox.Show("Güncelleme işlemi başarılı! Program yeniden başlatılacak!", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
                else
                    MessageBox.Show("Lütfen boş alan bırakmayınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception error)
            {
                MessageBox.Show("Güncelleme işlemi gerçekleştirilemedi! Hatanın sebebi;\n" + error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
