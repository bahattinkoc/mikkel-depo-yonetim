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
    public partial class ayarlar : Form
    {
        public ayarlar()
        {
            InitializeComponent();
        }

        void LoadSet()
        {
            numAltSinir.Value = Properties.Settings.Default.talepSınır;
            numTeslimTarihGun.Value = Properties.Settings.Default.teslimGun;
            numTalepMiktar.Value = Properties.Settings.Default.talepMiktar;
        }

        private void ayarlar_Load(object sender, EventArgs e)
        {
            LoadSet();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.talepSınır = Convert.ToInt32(numAltSinir.Value);
            Properties.Settings.Default.teslimGun = Convert.ToInt32(numTeslimTarihGun.Value);
            Properties.Settings.Default.talepMiktar = Convert.ToInt32(numTalepMiktar.Value);
            Properties.Settings.Default.Save();

            lblDurum.Text = "Kaydedildi!";
            lblDurum.Visible = true;
        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.talepSınır = 30;
            Properties.Settings.Default.teslimGun = 7;
            Properties.Settings.Default.talepMiktar = 100;
            Properties.Settings.Default.Save();
            LoadSet();

            lblDurum.Text = "Varsayılan ayarlar yüklendi";
            lblDurum.Visible = true;
        }

        private void numAltSinir_ValueChanged(object sender, EventArgs e)
        {
            lblDurum.Visible = false;
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
