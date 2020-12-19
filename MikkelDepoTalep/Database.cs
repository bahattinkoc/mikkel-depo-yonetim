using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Windows.Forms;

namespace MikkelDepoTalep
{
    class Database
    {
        public MySqlConnection connection;
        public MySqlCommand command;
        public MySqlDataReader reader;
        public MySqlDataAdapter adapter;
        public bool state = false;

        public void LoadDB()
        {
            connection = new MySqlConnection("Server=localhost;Database=mikkelDB;Uid=root;Pwd='';");
            try
            {
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }

                connection.Open();
                command = connection.CreateCommand();

                if (connection.State != System.Data.ConnectionState.Closed)
                    state = true;
                else 
                    state = false;
            }
            catch (System.Exception error)
            {
                MessageBox.Show("HATA! Veritabanı bağlantısı sağlanamadı!\nKarşılaşılan hata;\n" + error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public string GetValue(string _command, string value)
        {
            LoadDB();
            command.CommandText = _command;
            reader = command.ExecuteReader();
            if (reader.Read())
                return reader[value].ToString();
            else
                return String.Empty;
        }

        public bool IsExist(string _command, string value)//var mı yok mu
        {
            string varMi = GetValue(_command, value);
            if (!String.IsNullOrEmpty(varMi))
                return true;
            else
                return false;
        }

        public bool Delete(string _command)
        {
            LoadDB();//DELETE FROM sepet WHERE barkod = '002'
            command.CommandText = _command;
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Truncate(string table)
        {
            LoadDB();
            command.CommandText = "TRUNCATE TABLE " + table;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Tablo silme başarısız!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ComboBoxLoader(string table, string column, ComboBox cmb)
        {
            LoadDB();
            command.CommandText = "SELECT * FROM " + table;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                    cmb.Items.Add(reader[column].ToString());
            }
            catch (Exception error)
            {
                MessageBox.Show("Hata yeri: Database.ComboboxLoader\nHata:\n" + error.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
