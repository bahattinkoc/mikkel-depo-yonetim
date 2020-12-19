using MySql.Data.MySqlClient;
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
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        Database mikkelDB = new Database();
        public bool successLogin = false;
        public string name, userName;

        private void Form1_Load(object sender, EventArgs e)
        {
            DBControl();
        }

        void DBControl()
        {
            dbStateText.Text = "---";
            mikkelDB.LoadDB();
            if (mikkelDB.state)
            {
                dbStateText.Text = "Okay";
                dbStateText.ForeColor = Color.Green;
            }
            else
            {
                dbStateText.Text = "Hata";
                dbStateText.ForeColor = Color.Red;
            }
            mikkelDB.connection.Close();
        }

        private void girisYapButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(kulAdiText.Text) && !String.IsNullOrEmpty(sifreText.Text))
            {
                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "SELECT * FROM admin WHERE username = @username AND password = @password";
                    mikkelDB.command.Parameters.AddWithValue("@username", kulAdiText.Text);
                    mikkelDB.command.Parameters.AddWithValue("@password", sifreText.Text);
                    mikkelDB.reader = mikkelDB.command.ExecuteReader();

                    if (mikkelDB.reader.Read())
                    {
                        successLogin = true;
                        name = mikkelDB.reader["name"].ToString() + " " + mikkelDB.reader["surname"]; //kulAdiText.Text;
                        userName = mikkelDB.reader["username"].ToString();
                        mikkelDB.connection.Close();
                        Close();
                    }
                    else
                    {
                        mikkelDB.connection.Close();
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı!\nLütfen tekrar deneyiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }  
                }
                catch (Exception error)
                {
                    MessageBox.Show("HATA! Mesaj; \n" + error.Message);
                    throw;
                }
            }
            else
                MessageBox.Show("Kullanıcı adı veya şifre boş bırakılamaz!\nLütfen kullanıcı adı ve şifrenizi girerek tekrar deneyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void uyeKaydiButton_Click(object sender, EventArgs e)
        {
            adminKayitForm akF = new adminKayitForm();
            akF.ShowDialog();
        }

        private void kayitSilButon_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(kulAdiText.Text) && !String.IsNullOrEmpty(sifreText.Text))
            {
                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "SELECT * FROM admin WHERE username = @username AND password = @password";
                    mikkelDB.command.Parameters.AddWithValue("@username", kulAdiText.Text);
                    mikkelDB.command.Parameters.AddWithValue("@password", sifreText.Text);
                    mikkelDB.reader = mikkelDB.command.ExecuteReader();

                    if (mikkelDB.reader.Read())//silinecek veri varsa
                    {
                        mikkelDB.LoadDB();
                        mikkelDB.command.CommandText = "DELETE FROM admin WHERE username = @username AND password = @password";
                        mikkelDB.command.Parameters.AddWithValue("@username", kulAdiText.Text);
                        mikkelDB.command.Parameters.AddWithValue("@password", sifreText.Text);
                        mikkelDB.reader = mikkelDB.command.ExecuteReader();
                        MessageBox.Show("Silme işlemi başarılı!", "Admin Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        kulAdiText.Clear();
                        sifreText.Clear();
                    }
                    else
                        MessageBox.Show("Silinecek kayıt bulunamadı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Silme işlemi gerçekleştirilemedi! Hatanın sebebi;\n" + error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Gerekli alanları boş bırakmayınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
