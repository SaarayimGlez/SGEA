using Logica;
using Modelo;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace SGEA_DS
{
    public partial class CU18 : VentanaCtrolEvento
    {
        private int eventoId;

        public CU18(/*int idEvento*/)
        {
            InitializeComponent();
            this.eventoId = 1;
            llenarCampos(eventoId);
        }

        private void llenarCampos(int idEvento)
        {
            /*Evento_Logica evento_Logica = new Evento_Logica();
            if (!evento_Logica.ComprobarConexion())
            {
                textBlock_Mensaje.Text = "sin conexion";
                click_Aceptar(new object(), new RoutedEventArgs());
            }
            else
            {
                Evento eventoModificar = evento_Logica.RecuperarEvento(idEvento);

                textbox_Nombre.Text = eventoModificar.nombre;
                textbox_Lugar.Text = eventoModificar.lugar;
                combobox_IOrganizadora.Text = eventoModificar.institucionOrganizadora;
                datePicker_FInicio.Text = eventoModificar.fechaInicio.ToString("dd/MM/yyyy");
                datePicker_FFin.Text = eventoModificar.fechaFin.ToString("dd/MM/yyyy");
            }*/
        }

        private void click_Aceptar(object sender, RoutedEventArgs e)
        {
            /*if (textBlock_Mensaje.Text.Equals("sin conexion") || validarDatos())
            {
                modificarEvento();
                if (!textBlock_Mensaje.Text.Equals("Se ha perdido conexión con la base de datos"))
                {
                    textBlock_Mensaje.Text = String.Empty;
                    var bold = new Bold(new Run("Evento modificado con éxito"));
                    textBlock_Mensaje.Inlines.Add(bold);
                }
                button_Cancelar.Content = "Regresar";
                button_Aceptar.Visibility = Visibility.Hidden;
                textbox_Nombre.IsEnabled = false;
                textbox_Lugar.IsEnabled = false;
                combobox_IOrganizadora.IsEnabled = false;
                datePicker_FInicio.IsEnabled = false;
                datePicker_FFin.IsEnabled = false;
            }
            else
            {
                textBlock_Mensaje.Text = String.Empty;
                var bold = new Bold(
                    new Run("Hay datos inválidos o incompletos, favor de revisar")
                    {
                        Foreground = Brushes.Red
                    });
                textBlock_Mensaje.Inlines.Add(bold);
            }*/
        }
        
        private bool modificarEvento()
        {
            /*Evento_Logica evento_Logica = new Evento_Logica();
            if (textBlock_Mensaje.Text.Equals("sin conexion") || 
                !evento_Logica.ComprobarConexion())
            {
                textBlock_Mensaje.Text = String.Empty;
                textBlock_Mensaje.Text = "Se ha perdido conexión con la base de datos";
                textBlock_Mensaje.Foreground = Brushes.Red;
                textBlock_Mensaje.FontWeight = FontWeights.Bold;
                return true;
            }

            Evento eventoActualizado = new Evento()
            {
                Id = eventoId,
                nombre = textbox_Nombre.Text,
                lugar = textbox_Lugar.Text,
                institucionOrganizadora = combobox_IOrganizadora.Text,
                fechaInicio = Convert.ToDateTime(datePicker_FInicio.Text),
                fechaFin = Convert.ToDateTime(datePicker_FInicio.Text)
            };

            return evento_Logica.ModificarEvento(eventoActualizado);*/
            return true;
        }

        private bool validarDatos()
        {

            /*if (string.IsNullOrWhiteSpace(textbox_Nombre.Text) || 
                string.IsNullOrWhiteSpace(textbox_Lugar.Text) || 
                string.IsNullOrEmpty(datePicker_FInicio.Text) ||
                string.IsNullOrEmpty(datePicker_FInicio.Text))
            { 
                return false;
            }*/
            return true;
        }

        private void click_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
