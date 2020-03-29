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
using DataAccess;
using Logica;

namespace Controlador
{
    public partial class CU04 : Window
    {
        private int eventoId;
        private ComiteDAO comiteDAO;

        public CU04()
        {
            InitializeComponent();
        }

        public CU04(int eventoId)
        {
            this.eventoId = eventoId;
            InitializeComponent();
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
            nuevoComite.EventoId = 2;//eventoId
            comiteDAO = new ComiteDAO();
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
            this.Close();
        }

    }
}