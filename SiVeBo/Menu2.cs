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
    public partial class Menu2 : Form
    {
        DBconnection conexionBD;
        public Menu2(DBconnection conexionBD, Usuario user)
        {
            InitializeComponent();
            this.conexionBD = conexionBD;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ResaltaSeleccion(3);
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            AbrirFormPanel(new ControlUsuarios(conexionBD));
        }

        private void btnBoletos_Click(object sender, EventArgs e)
        {
            ResaltaSeleccion(1);
            int anchoPanel = panelContenedor.Width;
            int anchOpciones = Opciones.Width;
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            AbrirFormPanel(new Venta(conexionBD, anchoPanel, anchOpciones));
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            ResaltaSeleccion(2);
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ResaltaSeleccion(4);
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
        }

        private void Menu2_Load(object sender, EventArgs e)
        {
            panelContenedor.Location = new Point(Opciones.Width,0);
            panelContenedor.Width = this.Width - Opciones.Width;
            panelContenedor.Height = this.Height; ;
        }

        private void AbrirFormPanel(object FormPanel)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form FP = FormPanel as Form;
            FP.TopLevel = false;
            FP.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(FP);
            this.panelContenedor.Tag = FP;
            FP.Show();
        }

        private void ResaltaSeleccion(int seleccion)
        {
            btnBoletos.BackColor = btnHorarios.BackColor = btnUsuarios.BackColor = btnReportes.BackColor = Color.FromArgb(26, 32, 40);
            switch(seleccion)
            {
                case 1:
                    btnBoletos.BackColor = Color.FromArgb(64, 64, 64);
                    break;

                case 2:
                    btnHorarios.BackColor = Color.FromArgb(64, 64, 64);
                    break;

                case 3:
                    btnUsuarios.BackColor = Color.FromArgb(64, 64, 64);
                    break;

                case 4:
                    btnReportes.BackColor = Color.FromArgb(64, 64, 64);
                    break;
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
