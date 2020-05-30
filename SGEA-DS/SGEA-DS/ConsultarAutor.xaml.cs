using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Logica;
using Modelo;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para CU41.xaml
    /// </summary>
    public partial class CU41 : UserControl
    {
        private MiembroComite miembroComite;
        private List<RadioButton> listaRbAutor;
        private List<List<string>> listaAutor;

        public CU41()
        {
            InitializeComponent();
        }

        public CU41(MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            LlenarListaAutores();
        }

        private void LlenarListaAutores()
        {
            Autor_Logica autor_Logica = new Autor_Logica();
            if (!autor_Logica.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Se ha perdido conexión con la base de datos")
                {
                    Foreground = Brushes.Red
                });
                textBlock_mensaje.Inlines.Add(bold);
            }
            else
            {
                listaAutor =
                    autor_Logica.RecuperarAutor();
                listaRbAutor = new List<RadioButton>();

                foreach (List<string> autor in listaAutor)
                {
                    InsertarAutor(autor[0] + " " + autor[1] + " " + autor[2]);
                }
            }
        }

        private void InsertarAutor(string nombreCompletoAutor)
        {
            grid_Autores.RowDefinitions.Insert(
                grid_Autores.RowDefinitions.Count, new RowDefinition());
            var rbPatrocinador = new RadioButton();
            rbPatrocinador.Content = nombreCompletoAutor;
            rbPatrocinador.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            rbPatrocinador.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            rbPatrocinador.Height = 18;
            rbPatrocinador.Width = 350;
            rbPatrocinador.RenderTransformOrigin = new Point(0.5, 0.5);
            rbPatrocinador.FontSize = 14;
            TransformGroup transformGroupRb = new TransformGroup();
            transformGroupRb.Children.Add(new ScaleTransform(2, 2));
            rbPatrocinador.RenderTransform = transformGroupRb;
            grid_Autores.Children.Add(rbPatrocinador);
            Grid.SetRow(rbPatrocinador, grid_Autores.RowDefinitions.Count - 1);
            listaRbAutor.Add(rbPatrocinador);
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            GestionAutorArticulo gestionAutor = new GestionAutorArticulo(this.miembroComite);
            gestionAutor.Show();
            var window = Window.GetWindow(this);
            window.Close();
        }

        private void Click_VerDetalles(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listaRbAutor.Count; i++)
            {
                if (listaRbAutor[i].IsChecked == true)
                {
                    Switcher.Switch(new CU41_2(listaAutor[i], this.miembroComite));
                }
            }
        }
    }
}
