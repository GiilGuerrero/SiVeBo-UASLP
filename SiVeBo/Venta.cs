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

namespace SiVeBo
{
    public partial class Venta : Form
    {
        DBconnection conexionBD;
        MySqlDataAdapter DA;
        MySqlCommand comando;
        MySqlDataReader reader;
        string query = "";
        public Venta(DBconnection conexion, int AP, int AO)
        {
            InitializeComponent();
            this.conexionBD = conexion;
            int x = (AO + AP) - 550;
            GBAsientos.Location = new Point(x, 70);
        }

        private void pbBus_Click(object sender, EventArgs e)
        {

        }

        private void tbOrigen_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            query = "SELECT nombre FROM origen WHERE nombre like '%" + tbOrigen.Text + "'";
            comando = new MySqlCommand(query, conexionBD.Connection);

            try
            {
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    tbOrigen.AutoCompleteCustomSource.Add(reader["nombre"].ToString());
                }
            }
            catch (Exception exception)
            {
                reader.Close();
                MessageBox.Show(exception.Message);
                Close();
            }
        }
    }
}
