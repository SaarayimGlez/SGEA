using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace SGEA_DS
{
    public partial class Gafete : Window
    {

        public Gafete(string nombre)
        {
            InitializeComponent();
            textBlock_nombre.Text = nombre;
            Loaded += delegate
            {
                DescargarGafete();
            };
        }

        private void DescargarGafete()
        {
            Random rnd = new Random();
            int codigo = rnd.Next(52);
            string folderPath = KnownFolders.Downloads.Path + 
                @"\DiplomasYGafetes\Gafete" + codigo.ToString() + ".png";
            DirectoryInfo di = Directory.CreateDirectory(Path.GetDirectoryName(folderPath));
            string file = folderPath;
            BitmapEncoder encoder = new PngBitmapEncoder();
            RenderTargetBitmap pngFinal;

            this.grid_gafete.Width = (int)this.grid_gafete.ActualWidth;
            this.grid_gafete.Height = (int)this.grid_gafete.ActualHeight;
            this.canvas_gafete.Width = (int)this.canvas_gafete.ActualWidth;
            this.canvas_gafete.Height = (int)this.canvas_gafete.ActualHeight;

            int width = (int)this.grid_gafete.ActualWidth;
            int height = (int)this.grid_gafete.ActualHeight;

            pngFinal = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
            pngFinal.Render(this.grid_gafete);
            encoder.Frames.Add(BitmapFrame.Create(pngFinal));

            using (Stream stm = File.Create(file))
            {
                encoder.Save(stm);
            }
            this.Close();
        }

    }
}
