using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SiVeBo
{
    public class DBconnection
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;
        private DBconnection()
        {
        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBconnection _instance = null;
        public static DBconnection Instance()
        {
            if (_instance == null)
                _instance = new DBconnection();
            return _instance;
        }

        public bool IsConnected()
        {
            bool result = true;
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    result = false;
                //string connstring = string.Format("Server=localhost; database={0}; UID=UserName; password=your password", databaseName);
                string connstring = string.Format("Server=localhost; database={0}; UID=root", databaseName);
                connection = new MySqlConnection(connstring);
                connection.Open();
                result = true;
            }

            return result;
        }

        public void Close()
        {
            connection.Close();
        }

        public void autoCompletar(TextBox cajaTexto)
        {
            try
            {
                cmd = new SqlCommand("Select Nombre from origen", cnn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cajaTexto.AutoCompleteCustomSource.Add(dr["Nombre"].ToString());
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo autocompletar el TextBox: " + ex.ToString());
            }
        }
    }
}

