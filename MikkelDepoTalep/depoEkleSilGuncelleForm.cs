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
    public partial class depoEkleSilGuncelleForm : Form
    {
        Database mikkelDB = new Database();
        string barkod, adet, kategori, marka, urun;


        public depoEkleSilGuncelleForm()
        {
            InitializeComponent();
        }

        void cmbListele(ComboBox cmb, string command, string show)
        {
            mikkelDB.LoadDB();
            mikkelDB.command.CommandText = "SELECT * FROM " + command;
            mikkelDB.reader = mikkelDB.command.ExecuteReader();
            cmb.Items.Clear();
            while (mikkelDB.reader.Read())
                cmb.Items.Add(mikkelDB.reader[show]);
        }

        void butonChange()
        {
            barkod = mikkelDB.GetValue("SELECT * FROM urun WHERE name='" + urun + "' AND kategori_no='" + kategori + "' AND marka_no='" + marka + "'", "barkod");
            adet = mikkelDB.GetValue("SELECT * FROM depo WHERE barkod='"+barkod+"'", "adet");

            if (!String.IsNullOrEmpty(adet) && !String.IsNullOrEmpty(urun))
            {
                btnKaydet.Enabled = false;
                btnSil.Enabled = true;
                btnGuncelle.Enabled = true;
                numericUpDown1.Value = Convert.ToInt32(adet);
            }
            else
            {
                btnKaydet.Enabled = true;
                btnSil.Enabled = false;
                btnGuncelle.Enabled = false;
                numericUpDown1.Value = 1;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(barkod))
            {
                mikkelDB.LoadDB();
                mikkelDB.command.CommandText = "DELETE FROM depo WHERE barkod=@barkod";
                mikkelDB.command.Parameters.AddWithValue("@barkod", barkod);
                mikkelDB.command.ExecuteNonQuery();

                MessageBox.Show(barkod + " barkodlu ürün depodan silindi!", "Silme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Silmek için bir ürün seçmelisiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(barkod))
            {
                mikkelDB.LoadDB();
                mikkelDB.command.CommandText = "UPDATE depo SET adet=@adet WHERE barkod=@barkod";
                mikkelDB.command.Parameters.AddWithValue("@barkod", barkod);
                mikkelDB.command.Parameters.AddWithValue("@adet", numericUpDown1.Value);
                mikkelDB.command.ExecuteNonQuery();

                MessageBox.Show(barkod + " barkodlu ürün güncellendi!", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Güncellemek için bir ürün seçmelisiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void depoEkleSilGuncelleForm_Load(object sender, EventArgs e)
        {
            cmbListele(cmbKategori, "kategori", "kategori");
            cmbListele(cmbMarka, "marka", "marka");

            if (!String.IsNullOrEmpty(marka) && !String.IsNullOrEmpty(kategori))
                cmbListele(cmbUrun, "urun WHERE kategori_no='" + kategori + "' AND marka_no='" + marka + "'", "name");
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

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            kategori = cmbKategori.Text;
            marka = cmbMarka.Text;

            if(!String.IsNullOrEmpty(marka) && !String.IsNullOrEmpty(kategori))
            {
                cmbListele(cmbUrun, "urun WHERE kategori='" + kategori + "' AND marka='" + marka + "'", "name");
                butonChange();
            }
        }

        private void cmbUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            urun = cmbUrun.Text;
            butonChange();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(kategori) && !String.IsNullOrEmpty(marka) && !String.IsNullOrEmpty(urun))
            {
                try
                {
                    mikkelDB.LoadDB();
                    mikkelDB.command.CommandText = "INSERT INTO depo (barkod, adet) VALUES (@barkod, @adet)";
                    mikkelDB.command.Parameters.AddWithValue("@barkod", barkod);
                    mikkelDB.command.Parameters.AddWithValue("@adet", numericUpDown1.Value);
                    mikkelDB.command.ExecuteNonQuery();

                    MessageBox.Show("Kaydetme işlemi başarılı!", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Kayıt sırasında bir hata oluştu!\nHata:\n" + error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
            else
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
