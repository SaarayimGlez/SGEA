using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Logica;
using Microsoft.WindowsAPICodePack.Shell;

namespace SGEA_DS
{
    public partial class CU05 : Window {
        
        public CU05()
        {
            InitializeComponent();
            llenarListaActividades(1, "NombreDeEvent");
        }

        public CU05(int eventoId, string nombreEvento)
        {
            InitializeComponent();
            llenarListaActividades(eventoId, nombreEvento);
        }

        private void llenarListaActividades(int eventoId, string nombreEvento)
        {
            label_Evento.Content = nombreEvento;
            Actividad_Logica actividadDAO = new Actividad_Logica();
            if (!actividadDAO.ComprobarConexion())
            {
                textBlock_Mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Se ha perdido conexión con la base de datos")
                {
                    Foreground = Brushes.Red
                });
                textBlock_Mensaje.Inlines.Add(bold);
                button_Cancelar.Content = "Regresar";
                button_Aceptar.Visibility = Visibility.Hidden;            }
            else
            {
                List<List<string>> listaActividades = actividadDAO.RecuperarProgramaEvento(eventoId);
                foreach (List<string> actividad in listaActividades)
                {
                    insertarFila(actividad);
                }
            }
        }

        private void insertarFila(List<string> actividad)
        {
            grid_Programa.RowDefinitions.Add(new RowDefinition());
            int row = grid_Programa.RowDefinitions.Count - 1;
            int column = grid_Programa.ColumnDefinitions.Count;
            var rectangulo = new Rectangle();

            List<TextBlock> listaTxtBlock = new List<TextBlock>();
            List<Label> listaLabel = new List<Label>();
            for (int i = 0; i < 7; i++)
            {
                listaTxtBlock.Add(new TextBlock());
                listaTxtBlock[i].TextWrapping = TextWrapping.Wrap;
            }
            listaTxtBlock[0].Text = actividad[0];

            if(actividad[1].Equals("0"))
            {
                listaTxtBlock[1].Text = "";
            }
            else
            {
                listaTxtBlock[1].Text = "$" + actividad[1];
            }

            listaTxtBlock[2].Text = actividad[2];
            listaTxtBlock[3].Text = actividad[3];
            listaTxtBlock[4].Text = actividad[4];
            listaTxtBlock[6].Text = actividad[5];
            listaTxtBlock[5].Text = actividad[7];

            rectangulo.Fill = definirColor(actividad[6]);
            grid_Programa.Children.Add(rectangulo);
            Grid.SetRow(rectangulo, row);
            Grid.SetColumnSpan(rectangulo, column);

            for (int i = 0; i < 7; i++)
            {
                listaLabel.Add(new Label());
                listaLabel[i].Content = listaTxtBlock[i];
                grid_Programa.Children.Add(listaLabel[i]);
                Grid.SetRow(listaLabel[i], row);
                Grid.SetColumn(listaLabel[i], i);
            }
        }

        private Brush definirColor(string tipo)
        {
            string color = "";
            switch (tipo)
            {
                case "Acto protocolario":
                    color = "#BCC8CA";
                    break;
                case "Ponencia":
                    color = "#F3BFBB";
                    break;
                case "Curso":
                    color = "#CFCABC";
                    break;
                case "Conferencia":
                    color = "#ACC5EF";
                    break;
                case "Exposicion":
                    color = "#EDFFE6";
                    break;
                case "Entretenimiento":
                    color = "#A6EB84";
                    break;
                case "Mesa redonda":
                    color = "#FFDDD9";
                    break;
                default:
                    color = "#FFFFFF";
                    break;
            }
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
        }

        private void click_Aceptar(object sender, RoutedEventArgs e)
        {
            string file = KnownFolders.Downloads.Path + @"\programaIMG.png";
            BitmapEncoder encoder = new PngBitmapEncoder();
            RenderTargetBitmap pngFinal;

            this.grid_Programa.Width = (int)this.grid_Programa.ActualWidth;
            this.grid_Programa.Height = (int)this.grid_Programa.ActualHeight;
            this.canvas_Programa.Width = (int)this.grid_Programa.ActualWidth;
            this.canvas_Programa.Height = (int)this.grid_Programa.ActualHeight;
            this.grid_Tipo.Width = (int)this.grid_Tipo.ActualWidth;
            this.grid_Tipo.Height = (int)this.grid_Tipo.ActualHeight;
            this.canvas_Tipo.Width = (int)this.grid_Tipo.ActualWidth;
            this.canvas_Tipo.Height = (int)this.grid_Tipo.ActualHeight;
            
            int width = (int)this.grid_Programa.ActualWidth;
            int height = (int)this.grid_Programa.ActualHeight;

            pngFinal = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
            pngFinal.Render(this.grid_Programa);
            pngFinal.Render(this.grid_Tipo);
            encoder.Frames.Add(BitmapFrame.Create(pngFinal));

            using (Stream stm = File.Create(file))
            {
                encoder.Save(stm);
            }

            textBlock_Mensaje.Text = String.Empty;
            var bold = new Bold(new Run(@"Programa descargado en \Descargas\ProgramaIMG.png"));
            textBlock_Mensaje.Inlines.Add(bold);
            button_Cancelar.Content = "Regresar";
            button_Aceptar.Visibility = Visibility.Hidden;
        }
        
        private void click_Cancelar(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

    }
}
