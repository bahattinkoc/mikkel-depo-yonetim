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
    public partial class listele : Form
    {
        string type, typeDB, where;
        Database mikkelDB = new Database();

        public listele(string _type, string _DB, string _where)
        {
            InitializeComponent();
            type = _type;
            typeDB = _DB;
            where = _where;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if(Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void listele_Load(object sender, EventArgs e)
        {
            string command;
            this.Text = type + " Listesi";
            mikkelDB.LoadDB();
            if(String.IsNullOrEmpty(where)) command = "SELECT * FROM " + typeDB;
            else command = "SELECT * FROM " + typeDB + " WHERE " + where;
            mikkelDB.adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(command, mikkelDB.connection);
            DataTable dt = new DataTable();
            mikkelDB.adapter.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }
}
