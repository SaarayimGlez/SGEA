using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para Diploma.xaml
    /// </summary>
    public partial class Diploma : Window
    {
        public Diploma(List<string> ponente, Modelo.Evento evento)
        {
            InitializeComponent();
            nombre.Text = ponente[0];
            eventoNombre.Text = evento.nombre;
            instOrganizadora.Text = evento.institucionOrganizadora;
            lugar.Text = evento.lugar;
            fecha.Text = ponente[1];
            Loaded += delegate
            {
                DescargarDiploma();
            };
        }
        
        private void DescargarDiploma()
        {
            Random rnd = new Random();
            int codigo = rnd.Next(52);
            string folderPath = KnownFolders.Downloads.Path +
                @"\DiplomasYGafetes\Diploma" + codigo.ToString() + ".png";
            string file = folderPath;
            BitmapEncoder encoder = new PngBitmapEncoder();
            RenderTargetBitmap pngFinal;

            this.grid_diploma.Width = (int)this.grid_diploma.ActualWidth;
            this.grid_diploma.Height = (int)this.grid_diploma.ActualHeight;
            this.canvas_diploma.Width = (int)this.canvas_diploma.ActualWidth;
            this.canvas_diploma.Height = (int)this.canvas_diploma.ActualHeight;

            int width = (int)this.grid_diploma.ActualWidth;
            int height = (int)this.grid_diploma.ActualHeight;

            pngFinal = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
            pngFinal.Render(this.grid_diploma);
            encoder.Frames.Add(BitmapFrame.Create(pngFinal));

            using (Stream stm = File.Create(file))
            {
                encoder.Save(stm);
            }
            this.Close();
        }
    }
}
