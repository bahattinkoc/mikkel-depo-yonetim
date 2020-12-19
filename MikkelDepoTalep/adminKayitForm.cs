using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MikkelDepoTalep
{
    public partial class adminKayitForm : Form
    {
        public adminKayitForm()
        {
            InitializeComponent();
        }

        Database mikkelDB = new Database();

        private void adminKayitForm_Load(object sender, EventArgs e)
        {

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
                    mikkelDB.command = mikkelDB.connection.CreateCommand();
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
                        MessageBox.Show("Kayıt oluşturulurken bir hata ile karşılaşıldı.\nHata mesajı;\n" + error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Bu hatayı almanızın olası sebepleri aşağıda listelenmiştir;\n* Eğer boş bıraktıysanız lütfen gerekli alanları doldurarak tekrar deneyiniz.\n* Var olan bir kullanıcı adını tekrar eklmeye çalışmayınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
