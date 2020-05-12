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
        public Diploma()
        {
            InitializeComponent();
            DescargarDiploma();
        }

        private void DescargarDiploma()
        {
            string file = KnownFolders.Downloads.Path + @"\programaIMG.png";
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
        }
    }
}
