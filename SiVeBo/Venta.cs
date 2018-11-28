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
using AForge.Video.DirectShow;
using BarcodeLib.BarcodeReader;
using Gma.QrCodeNet.Encoding; //ToDo
using Gma.QrCodeNet.Encoding.Windows.Render;//ToDo
using System.IO;
using System.Drawing.Imaging;

namespace SiVeBo
{
    public partial class Venta : Form
    {
        DBconnection conexionBD;
        MySqlCommand comando;
        MySqlDataReader reader;
        private FilterInfoCollection dispositivos;
        private VideoCaptureDevice FuenteVideo;
        string query = "", folio="";
        private int CantBoletosNE = 0, CantBoletosA = 0, CantBoletosTE = 0, totalBoletos = 0, contaBoletos = 0, idUsuario = 0;
        private double precioBoleto = 0, cambio = 0, total = 0;
        private bool clickAsiento = false, usado = false;
        private List<int> listaAsientosSelec = new List<int>();
        public Venta(DBconnection conexion, int AP, int AO, int idUser)
        {
            InitializeComponent();
            this.conexionBD = conexion;
            int x = (AO + AP) - 550;
            tbBoletosNiñoEst.Text = CantBoletosNE.ToString();
            tbBoletoAdulto.Text = CantBoletosA.ToString();
            tbBoleto3Edad.Text = CantBoletosTE.ToString();
            //videoSourcePlayer1.Location = new Point(160, 35);
            cbHorario.Items.Add("05:45");
            cbHorario.Items.Add("06:20");
            cbHorario.Items.Add("07:30");
            cbHorario.Items.Add("08:05");
            cbHorario.Items.Add("09:15");
            dgvBoletos.ForeColor = Color.Black;
            idUsuario = idUser;
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            //query = "SELECT nombre FROM ciudad WHERE nombre like '%" + tbOrigen.Text + "'";
            panelAsientosBus.Location = new Point(this.Width-(panelAsientosBus.Width+35), 70);
            query = "SELECT nombre FROM ciudad ORDER BY nombre";
            comando = new MySqlCommand(query, conexionBD.Connection);

            try
            {
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    cbOrigen.Items.Add(reader["nombre"].ToString());
                    cbDestino.Items.Add(reader["nombre"].ToString());
                    //tbOrigen.AutoCompleteCustomSource.Add(reader["nombre"].ToString());
                    //tbDestino.AutoCompleteCustomSource.Add(reader["nombre"].ToString());
                    cbOrigen.AutoCompleteCustomSource.Add(reader["nombre"].ToString());
                    cbDestino.AutoCompleteCustomSource.Add(reader["nombre"].ToString());
                }
                ActivaCamara();
                reader.Close();
            }
            catch (Exception exception)
            {
                reader.Close();
                MessageBox.Show(exception.Message);
                Close();
            }
            
            
        }

        #region Eventos para manipular códigos QR
        private void ActivaCamara()
        {
            dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //FuenteVideo = new VideoCaptureDevice(dispositivos[0].MonikerString);
            foreach (FilterInfo FI in dispositivos)
             {
                cbDispositivos.Items.Add(FI.Name);
             }
             //cbDispositivos.SelectedIndex = 0;
        }


        /*
         * private void timer1_Tick(object sender, EventArgs e)
        {
            if (videoSourcePlayer1.GetCurrentVideoFrame() != null)
            {
                Bitmap img = new Bitmap(videoSourcePlayer1.GetCurrentVideoFrame());
                string[] folio = BarcodeReader.read(img, BarcodeReader.QRCODE);
                img.Dispose();
                if (resultados != null && resultados.Count() > 0)
                {
                    if (resultados[0].IndexOf("1111") != -1)
                    {
                        resultados[0] = resultados[0].Replace("1111", "");
                        label1.Text = resultados[0];
                    }
                    else label1.Text = resultados[0];
                }
            }

            
            /*
            if (videoSourcePlayer1.GetCurrentVideoFrame() != null)
            {
                Bitmap imgEscanear = new Bitmap(videoSourcePlayer1.GetCurrentVideoFrame());
                //UTILIZAR LA LIBRERIA Y LEER EL CÓDIGO
                string[] resultados = BarcodeReader.read(imgEscanear, BarcodeReader.QRCODE);
                //QUITAR LA IMAGEN DE MEMORIA
                imgEscanear.Dispose();
                //OBTENER LAS LECTURAS CUANDO SE LEA ALGO

                if (resultados != null && resultados.Count() > 0)
                {
                    //AGREGAR EL TEXTO OBTENIDO A LA LISTA
                    //LISTBOX1.ITEMS.ADD(RESULTADOS[0]);
                    lblResultadoQR.Text = resultados[0];
                }
            }
    }*/

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (videoSourcePlayer1.GetCurrentVideoFrame() != null)
            {
                Bitmap img = new Bitmap(videoSourcePlayer1.GetCurrentVideoFrame());
                string[] folio = BarcodeReader.read(img, BarcodeReader.QRCODE);
                img.Dispose();
                if (folio != null && folio.Count() >0)
                {
                    folio[0] = folio[0].TrimStart('X');
                    llenaFormulario(folio[0]);
                }
            }

            
            /*
            if (videoSourcePlayer1.GetCurrentVideoFrame() != null)
            {
                Bitmap imgEscanear = new Bitmap(videoSourcePlayer1.GetCurrentVideoFrame());
                //UTILIZAR LA LIBRERIA Y LEER EL CÓDIGO
                string[] resultados = BarcodeReader.read(imgEscanear, BarcodeReader.QRCODE);
                //QUITAR LA IMAGEN DE MEMORIA
                imgEscanear.Dispose();
                //OBTENER LAS LECTURAS CUANDO SE LEA ALGO

                if (resultados != null && resultados.Count() > 0)
                {
                    //AGREGAR EL TEXTO OBTENIDO A LA LISTA
                    //LISTBOX1.ITEMS.ADD(RESULTADOS[0]);
                    lblResultadoQR.Text = resultados[0];
                }
            }*/
        }

        private void GeneraQR(string folio)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(folio, out qrCode);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            var imageTemporal = new Bitmap(ms);
            var imagen = new Bitmap(imageTemporal, new Size(new Point(150, 150)));
            panelQR.BackgroundImage = imagen;

            // Guardar en el disco duro la imagen (Carpeta del proyecto)
            imagen.Save("C:\\Users\\ISABEL\\Desktop\\QR_Boleto.jpg", ImageFormat.Jpeg);
            //btnGuardar.Enabled = true;
        }

        #endregion

        #region Eventos de los botónes
        private void btnBoletosMas_Click(object sender, EventArgs e)
        {
            try
            {
                CantBoletosNE += 1;
                totalBoletos += 1;
                tbBoletosNiñoEst.Text = CantBoletosNE.ToString();
                tbCantBoletos.Text = totalBoletos.ToString();
                seleccionaPrecioBoleto(1);
                total += precioBoleto;
                //int numEntero = int.Parse(total.ToString().Split('.')[0]);
                //float numDecimal = float.Parse("0," + total.ToString().Split('.')[1]);
                //tbTotal.Text = "$ " + numEntero + "." + numDecimal;
                tbTotal.Text = total.ToString();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            //llenaFormulario(1);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            CantBoletosTE += 1;
            totalBoletos += 1;
            tbBoleto3Edad.Text = CantBoletosTE.ToString();
            tbCantBoletos.Text = totalBoletos.ToString();
            seleccionaPrecioBoleto(3);
            total += precioBoleto;
            tbTotal.Text = total.ToString();
        }

        private void btnBoletoMasA_Click(object sender, EventArgs e)
        {
            CantBoletosA += 1;
            totalBoletos += 1;
            tbBoletoAdulto.Text = CantBoletosA.ToString();
            tbCantBoletos.Text = totalBoletos.ToString();
            seleccionaPrecioBoleto(2);
            total += precioBoleto;
            tbTotal.Text = total.ToString();
            //llenaFormulario(3);
        }

        private void videoSourcePlayer1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FuenteVideo = new VideoCaptureDevice(dispositivos[cbDispositivos.SelectedIndex].MonikerString);
                videoSourcePlayer1.VideoSource = FuenteVideo;
                videoSourcePlayer1.Start();
                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            folio = "X420485";
            string valores = "";
            try
            {
                foreach (DataGridViewRow row in dgvBoletos.Rows)
                {
                    if(!row.IsNewRow)
                    {
                        query = valores = "";
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            valores += "'" + row.Cells[i].Value.ToString() + "'" + ",";
                        }
                        valores = "'" + folio + "'," + valores;
                        valores += usado;
                        valores = valores.TrimEnd(',');
                        query = "INSERT INTO venta (folio,origen,destino,fecha,tipoBol,asiento,usado) values (" + valores + ")";
                        comando = new MySqlCommand(query, conexionBD.Connection);
                        comando.ExecuteNonQuery();
                    }
                }
                GeneraQR(folio);
                MessageBox.Show("Registro éxitoso");
                limpiaControles();
            }
            catch (Exception exception)
            {
                reader.Close();
                MessageBox.Show("Ha fallado el registro de la venta");
                //Close();
            }
        }

        private void btnIntercCy_Click(object sender, EventArgs e)
        {
            int itemAux = cbOrigen.SelectedIndex;
            cbOrigen.SelectedItem = cbDestino.SelectedItem;
            cbDestino.SelectedItem = cbDestino.Items[itemAux];
        }

        private void btnHabAsientos_Click(object sender, EventArgs e)
        {
            if (!clickAsiento)
            {
                btnHabAsientos.BackColor = Color.Red;
                panelAsientosBus.Enabled = true;
                clickAsiento = true;
                totalBoletos = Convert.ToInt32(tbBoletosNiñoEst.Text) + Convert.ToInt32(tbBoletoAdulto.Text) + Convert.ToInt32(tbBoleto3Edad.Text);
            }
            else
            {
                btnHabAsientos.BackColor = Color.Green;
                panelAsientosBus.Enabled = false;
                clickAsiento = false;
                //llenaFormulario();
                //ToDo Registrar venta
            }
        }

        private void btnBoletoMenos_Click(object sender, EventArgs e)
        {
            try
            {
                CantBoletosNE -= 1;
                totalBoletos -= 1;
                tbBoletosNiñoEst.Text = CantBoletosNE.ToString();
                tbCantBoletos.Text = totalBoletos.ToString();
                seleccionaPrecioBoleto(1);
                total -= precioBoleto;
                //int numEntero = int.Parse(total.ToString().Split('.')[0]);
                //float numDecimal = float.Parse("0," + total.ToString().Split('.')[1]);
                //tbTotal.Text = "$ " + numEntero + "." + numDecimal;
                tbTotal.Text = total.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnBoletoMenosA_Click(object sender, EventArgs e)
        {
            try
            {
                CantBoletosA -= 1;
                totalBoletos -= 1;
                tbBoletosNiñoEst.Text = CantBoletosA.ToString();
                tbCantBoletos.Text = totalBoletos.ToString();
                seleccionaPrecioBoleto(2);
                total -= precioBoleto;
                //int numEntero = int.Parse(total.ToString().Split('.')[0]);
                //float numDecimal = float.Parse("0," + total.ToString().Split('.')[1]);
                //tbTotal.Text = "$ " + numEntero + "." + numDecimal;
                tbTotal.Text = total.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnBoletoMenosTE_Click(object sender, EventArgs e)
        {
            try
            {
                CantBoletosTE -= 1;
                totalBoletos -= 1;
                tbBoletosNiñoEst.Text = CantBoletosTE.ToString();
                tbCantBoletos.Text = totalBoletos.ToString();
                seleccionaPrecioBoleto(3);
                total -= precioBoleto;
                //int numEntero = int.Parse(total.ToString().Split('.')[0]);
                //float numDecimal = float.Parse("0," + total.ToString().Split('.')[1]);
                //tbTotal.Text = "$ " + numEntero + "." + numDecimal;
                tbTotal.Text = total.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button94_Click(object sender, EventArgs e)
        {
            string TipoBol = "";
            try
            {
                Button b = (Button)sender;
                if (b.BackColor == Color.Lime)
                {
                    if (contaBoletos <= totalBoletos - 1)
                    {
                        TipoBol = ObtenTipoBol();
                        contaBoletos++;
                        b.BackColor = Color.Red;
                        listaAsientosSelec.Add(Convert.ToInt32(b.Text));
                        dgvBoletos.Rows.Add(cbOrigen.Text, cbDestino.Text, cbHorario.Text, TipoBol, listaAsientosSelec[listaAsientosSelec.IndexOf(Convert.ToInt32(b.Text))]); 
                    }
                }
                else 
                {
                    contaBoletos--;
                    b.BackColor = Color.Lime;
                    listaAsientosSelec.Remove(Convert.ToInt32(b.Text));
                    foreach (DataGridViewRow row in dgvBoletos.Rows)
                    {
                        if (row.Cells[4].Value.Equals(Convert.ToInt32(b.Text)))
                        {
                            dgvBoletos.Rows.RemoveAt(row.Index);
                            break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }
        
        #endregion

        public void llenaFormulario(string folio)
        {
            query = "SELECT (origen,destino,fecha,tipoBol,asiento) FROM venta WHERE folio =" + folio;
            comando = new MySqlCommand(query, conexionBD.Connection);

            try
            {
                reader = comando.ExecuteReader();
                while (reader.Read())
                {

                    cbOrigen.Items.Add(reader["nombre"].ToString());
                    cbDestino.Items.Add(reader["nombre"].ToString());
                    //tbOrigen.AutoCompleteCustomSource.Add(reader["nombre"].ToString());
                    //tbDestino.AutoCompleteCustomSource.Add(reader["nombre"].ToString());
                    cbOrigen.AutoCompleteCustomSource.Add(reader["nombre"].ToString());
                    cbDestino.AutoCompleteCustomSource.Add(reader["nombre"].ToString());
                }
                ActivaCamara();
                reader.Close();
            }
            catch (Exception exception)
            {
                reader.Close();
                MessageBox.Show(exception.Message);
                Close();
            }
        }

        private string ObtenTipoBol()
        {
            string TipoBoleto = "";
            if (CantBoletosNE != 0)
            {
                TipoBoleto = "Nino/Estudiante";
                CantBoletosNE--;
            }
            else if (CantBoletosA != 0)
            {
                TipoBoleto = "Adulto";
                CantBoletosA--;
            }
            else
            {
                TipoBoleto = "Tercera edad";
                CantBoletosTE--;
            }

            return TipoBoleto;
        }

        private void seleccionaPrecioBoleto(int tB)
        {

            switch (tB)
            {
                case 1:
                    precioBoleto = 22.50;
                    break;
                case 2:
                    precioBoleto = 40;
                    break;
                case 3:
                    precioBoleto = 15;
                    break;
            }
        }

        private void limpiaControles()
        {
            tbFecha.Clear();
            tbBoleto3Edad.Clear();
            tbBoletoAdulto.Clear();
            tbBoletosNiñoEst.Clear();
            dgvBoletos.Rows.Clear();
            tbTotal.Text = "$0.00";
            tbEfectivo.Text = "$0.00";
            tbCambio.Text = "$0.00";
            tbCantBoletos.Text = "0";
            cbOrigen.SelectedIndex = -1;
            cbDestino.SelectedIndex = -1;
            cbHorario.SelectedIndex = -1;
            videoSourcePlayer1.Stop();
            btnHabAsientos.ForeColor = Color.Lime;
        }
        



    }
}
