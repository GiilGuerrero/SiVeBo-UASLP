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

namespace SiVeBo
{
    public partial class LectorQR : Form
    {
        private FilterInfoCollection dispositivos;
        private VideoCaptureDevice FuenteVideo;
        public LectorQR()
        {
            InitializeComponent();
        }

        private void LectorQR_Load(object sender, EventArgs e)
        {
            dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach(FilterInfo FI in dispositivos)
            {
                cbDispositivos.Items.Add(FI.Name);
            }
            cbDispositivos.SelectedIndex = 0;
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            FuenteVideo = new VideoCaptureDevice(dispositivos[cbDispositivos.SelectedIndex].MonikerString);
            videoSourcePlayer1.VideoSource = FuenteVideo;
            videoSourcePlayer1.Start();
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
             /*if(videoSourcePlayer1.GetCurrentVideoFrame() != null)
            {
                Bitmap imgEscanear = new Bitmap(videoSourcePlayer1.GetCurrentVideoFrame());
                //UTILIZAR LA LIBRERIA Y LEER EL CÓDIGO
                string[] resultados = BarcodeReader.read(imgEscanear, BarcodeReader.QRCODE);
                //QUITAR LA IMAGEN DE MEMORIA
                imgEscanear.Dispose();
                //OBTENER LAS LECTURAS CUANDO SE LEA ALGO

                if(resultados != null && resultados.Count() > 0)
                {
                    //AGREGAR EL TEXTO OBTENIDO A LA LISTA
                    //LISTBOX1.ITEMS.ADD(RESULTADOS[0]);
                }
            }*/
        }
    }
}
