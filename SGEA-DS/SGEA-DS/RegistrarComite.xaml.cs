using System;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using DataAccess;
using Logica;

namespace SGEA_DS
{
    public partial class CU04 : Window
    {
        private int eventoId;
        private string nombreEvento;
        private Comite_Logica comiteDAO;

        public CU04()
        {
            InitializeComponent();
            this.eventoId = 1;
        }

        public CU04(int eventoId, string nombreEvento)
        {
            InitializeComponent();
            this.eventoId = eventoId;
            this.nombreEvento = nombreEvento;
            this.Title = "Registrar lider de comité del evento: " + nombreEvento;
        }

        private void textbox_Alfabetico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
            }
            else
            {
                if (e.Key == Key.Oem3 | e.Key == Key.Oem1 | e.Key == Key.DeadCharProcessed)
                {
                }
                else
                {
                    e.Handled = true;
                }
            }

        }

        private void click_Aceptar(object sender, RoutedEventArgs e)
        {
            if (validarDatos() && nuevoComite())
            {
                textBlock_Mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Comité registrado con éxito"));
                textBlock_Mensaje.Inlines.Add(bold);
                button_Cancelar.Content = "Regresar";
                button_Aceptar.Visibility = Visibility.Hidden;
                textbox_Nombre.IsEnabled = false;
                textbox_Descripcion.IsEnabled = false;
            }
            else
            {
                textBlock_Mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Hay datos inválidos o el comité ya existe, favor de revisar") { Foreground = Brushes.Red });
                textBlock_Mensaje.Inlines.Add(bold);
            }
        }

        private bool nuevoComite()
        {
            Comite nuevoComite = new Comite();
            nuevoComite.nombre = textbox_Nombre.Text;
            nuevoComite.descripcion = textbox_Descripcion.Text;
            nuevoComite.EventoId = eventoId;
            comiteDAO = new Comite_Logica();
            return comiteDAO.RegistrarComite(nuevoComite);
        }

        private bool validarDatos()
        {
            if (textbox_Nombre.Text.Any(char.IsPunctuation) | textbox_Descripcion.Text.Any(char.IsPunctuation) |
                textbox_Nombre.Text.Any(char.IsDigit) | textbox_Descripcion.Text.Any(char.IsDigit) |
                string.IsNullOrWhiteSpace(textbox_Nombre.Text) | string.IsNullOrWhiteSpace(textbox_Descripcion.Text))
            {
                return false;
            }
            return true;
        }

        private void click_Cancelar(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(eventoId, nombreEvento);
            main.Show();
            this.Close();
        }

    }
}