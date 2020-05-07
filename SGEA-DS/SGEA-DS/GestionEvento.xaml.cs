using Logica;
using MaterialDesignThemes.Wpf;
using Modelo;
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

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para GestionEvento.xaml
    /// </summary>
    public partial class GestionEvento : Window
    {
        private Modelo.MiembroComite usuario;

        public GestionEvento(Modelo.MiembroComite usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            LlenarListaEventos(usuario);
        }

        public GestionEvento()
        {
            InitializeComponent();
            this.usuario = null;
            LlenarListaEventos(null);
        }

        private void LlenarListaEventos(Modelo.MiembroComite usuario)
        {
            Evento_Logica evento_Logica = new Evento_Logica();
            if (!evento_Logica.ComprobarConexion())
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
                List<Modelo.Evento> listaEvento;
                if (usuario != null)
                {
                    listaEvento = evento_Logica.RecuperarEventos(usuario.ComiteId);
                } else
                {
                    listaEvento = evento_Logica.RecuperarEventos(0);
                    MostrarCrearEvento();
                }

                foreach (Modelo.Evento evento in listaEvento)
                {
                    InsertarFila(evento, usuario);
                }
            }
        }

        private void MostrarCrearEvento()
        {
            label_instrucciones.Content = label_instrucciones.Content + " o crea uno nuevo";
            grid_crearEvento.RowDefinitions.Insert(
                grid_eventos.RowDefinitions.Count, new RowDefinition());
            var btnCrearEvento = new Button();
            btnCrearEvento.Content = "Crear evento";
            btnCrearEvento.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            btnCrearEvento.Width = 150;
            btnCrearEvento.FontSize = 18;
            btnCrearEvento.Click += Click_CrearEvento;
            grid_crearEvento.Children.Add(btnCrearEvento);
            Grid.SetRow(btnCrearEvento, grid_crearEvento.RowDefinitions.Count - 1);
        }

        private void Click_CrearEvento(object sender, RoutedEventArgs e)
        {
            RegistrarEvento evento = new RegistrarEvento();
            evento.Show();
            this.Close();
        }

        private void InsertarFila(Modelo.Evento evento, Modelo.MiembroComite usuarioActual)
        {
            grid_eventos.RowDefinitions.Insert(
                grid_eventos.RowDefinitions.Count, new RowDefinition());
            var gridEventoIndv = new Grid();
            gridEventoIndv.RowDefinitions.Add(new RowDefinition());
            var btnEvento = new Button();
            btnEvento.Content = new TextBlock() {
                Text = evento.nombre,
                TextWrapping = TextWrapping.WrapWithOverflow,
                TextAlignment = TextAlignment.Center
            };
            btnEvento.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            btnEvento.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            btnEvento.Height = 80;
            btnEvento.Width = 472;
            btnEvento.FontSize = 18;
            btnEvento.Click += (sender, EventArgs) => {
                Click_Evento(sender, EventArgs, evento);
            };
            if (usuarioActual == null)
            {
                var btnModificar = new Button();
                btnModificar.Content = new PackIcon() {
                    Kind = PackIconKind.Edit, Width = 64, Height = 40 };
                btnModificar.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                btnModificar.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                btnModificar.Height = 80;
                btnModificar.Width = 92;
                btnEvento.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                btnEvento.Width = 375;
                btnModificar.Click += (sender, EventArgs) => {
                    Click_ModificarEvento(sender, EventArgs, evento.Id); };
                gridEventoIndv.Children.Add(btnModificar);
            }
            gridEventoIndv.Children.Add(btnEvento);
            grid_eventos.Children.Add(gridEventoIndv);
            Grid.SetRow(gridEventoIndv, grid_eventos.RowDefinitions.Count - 1);
        }

        private void Click_ModificarEvento(object sender, RoutedEventArgs e, int eventoId)
        {
            throw new NotImplementedException();
        }

        private void Click_Evento(object sender, RoutedEventArgs e, Modelo.Evento evento)
        {
            if (this.usuario == null)
            {
                GestionEvento_2 gestionEvento_2 = new GestionEvento_2(evento);
                gestionEvento_2.Show();
                this.Close();
            }
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            MenuOrganizador menuOrganizador = new MenuOrganizador();
            menuOrganizador.Show();
            this.Close();
        }
    }
}
