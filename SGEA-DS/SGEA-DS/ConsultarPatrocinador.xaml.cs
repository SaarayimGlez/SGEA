using Modelo;
using Logica;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SGEA_DS {

    public partial class CU38 : UserControl
    {
        private List<RadioButton> listaRbPatrocinador;
        private List<Modelo.Patrocinador> listaPatrocinador;

        public CU38()
        {
            InitializeComponent();
            LlenarListaPatrocinadores();
        }

        private void LlenarListaPatrocinadores()
        {
            Patrocinador_Logica patrocinadorDAO = new Patrocinador_Logica();
            if (!patrocinadorDAO.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Se ha perdido conexión con la base de datos")
                    {
                        Foreground = Brushes.Red
                    });
                textBlock_mensaje.Inlines.Add(bold);
            } else
            {
                listaPatrocinador = 
                    patrocinadorDAO.RecuperarPatrocinador();
                listaRbPatrocinador = new List<RadioButton>();

                foreach (Modelo.Patrocinador patrocinador in listaPatrocinador)
                {
                    InsertarParticipante(patrocinador.empresa);
                }
            }
        }

        private void InsertarParticipante(string empresa)
        {
            grid_Patrocinadores.RowDefinitions.Insert(
                grid_Patrocinadores.RowDefinitions.Count, new RowDefinition());
            var rbPatrocinador = new RadioButton();
            rbPatrocinador.Content = empresa;
            rbPatrocinador.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            rbPatrocinador.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            rbPatrocinador.Height = 18;
            rbPatrocinador.Width = 350;
            rbPatrocinador.RenderTransformOrigin = new Point(0.5, 0.5);
            rbPatrocinador.FontSize = 14;
            TransformGroup transformGroupRb = new TransformGroup();
            transformGroupRb.Children.Add(new ScaleTransform(2, 2));
            rbPatrocinador.RenderTransform = transformGroupRb;
            grid_Patrocinadores.Children.Add(rbPatrocinador);
            Grid.SetRow(rbPatrocinador, grid_Patrocinadores.RowDefinitions.Count - 1);
            listaRbPatrocinador.Add(rbPatrocinador);
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            GestionPatrocinador gestionPatrocinador = new GestionPatrocinador();
            gestionPatrocinador.Show();
            var window = Window.GetWindow(this);
            window.Close();
        }

        private void Click_VerDetalles(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listaRbPatrocinador.Count; i++)
            {
                if (listaRbPatrocinador[i].IsChecked == true)
                {
                    Switcher.Switch(new CU38_2(listaPatrocinador[i]));
                }
            }
        }

    }
}
