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
    public partial class markategoriEkleSilForm : Form
    {
        string type, typeForDB;

        public markategoriEkleSilForm(string _type, string _DB)
        {
            InitializeComponent();
            type = _type;
            typeForDB = _DB;
        }

        Database mikkelDB = new Database();

        private void txtMarka_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMarkaKategori.Text))
            {
                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "SELECT * FROM "+ typeForDB + " WHERE "+ typeForDB + " = @name";
                    mikkelDB.command.Parameters.AddWithValue("@name", txtMarkaKategori.Text);
                    mikkelDB.reader = mikkelDB.command.ExecuteReader();
                    if (mikkelDB.reader.Read())
                    {
                        btnKaydet.Enabled = false;
                        btnSil.Enabled = true;
                    }
                    else
                    {
                        btnSil.Enabled = false;
                        btnKaydet.Enabled = true;
                    }
                }
                catch (Exception)
                {

                }
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMarkaKategori.Text))
            {
                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "INSERT INTO "+ typeForDB + " ("+ typeForDB + ") VALUES (@name)";
                    mikkelDB.command.Parameters.AddWithValue("@name", txtMarkaKategori.Text);
                    mikkelDB.command.ExecuteNonQuery();

                    MessageBox.Show("Kaydetme işlemi başarıyla gerçekleşti!", "Kaydetme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMarkaKategori.Text))
            {
                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "DELETE FROM "+ typeForDB + " WHERE "+ typeForDB + "=@name";
                    mikkelDB.command.Parameters.AddWithValue("@name", txtMarkaKategori.Text);
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

        private void markategoriEkleSilForm_Load(object sender, EventArgs e)
        {
            this.Text = type + " İşlemleri";
            label1.Text = type + " İşlemleri Formu";
            label2.Text = type + " Adı";
        }
    }
}
