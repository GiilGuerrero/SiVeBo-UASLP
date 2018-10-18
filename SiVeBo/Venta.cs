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
        string query = "";
        public Venta(DBconnection conexion, int AP, int AO)
        {
            InitializeComponent();
            this.conexionBD = conexion;
            int x = (AO + AP) - 550;
            GBAsientos.Location = new Point(x, 70);
            //videoSourcePlayer1.Location = new Point(160, 35);
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            query = "SELECT nombre FROM ciudad WHERE nombre like '%" + tbOrigen.Text + "'";
            comando = new MySqlCommand(query, conexionBD.Connection);

            try
            {
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    tbOrigen.AutoCompleteCustomSource.Add(reader["nombre"].ToString());
                    tbDestino.AutoCompleteCustomSource.Add(reader["nombre"].ToString());
                }
            }
            catch (Exception exception)
            {
                reader.Close();
                MessageBox.Show(exception.Message);
                Close();
            }
            ActivaCamara();
            
        }

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

        private void btnGeneraQR_Click(object sender, EventArgs e)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(tbDatosQR.Text, out qrCode);

            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);

            MemoryStream ms = new MemoryStream();

            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            var imageTemporal = new Bitmap(ms);
            var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
            panelQR.BackgroundImage = imagen;

            // Guardar en el disco duro la imagen (Carpeta del proyecto)
            imagen.Save("imagen.png", ImageFormat.Png);
            //btnGuardar.Enabled = true;
        }

        private void btnScanQR_Click(object sender, EventArgs e)
        {
            try
            {
                FuenteVideo = new VideoCaptureDevice(dispositivos[cbDispositivos.SelectedIndex].MonikerString);
                videoSourcePlayer1.VideoSource = FuenteVideo;
                videoSourcePlayer1.Start();
                timer1.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (videoSourcePlayer1.GetCurrentVideoFrame() != null)
            {
                Bitmap img = new Bitmap(videoSourcePlayer1.GetCurrentVideoFrame());
                string[] resultados = BarcodeReader.read(img, BarcodeReader.QRCODE);
                img.Dispose();
                if (resultados != null && resultados.Count() > 0)
                {
                    if (resultados[0].IndexOf("1111") != -1)
                    {
                        resultados[0] = resultados[0].Replace("1111", "");
                        lblResultadoQR.Text = resultados[0];
                    }
                    else
                        lblResultadoQR.Text = resultados[0];

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
    }
}
