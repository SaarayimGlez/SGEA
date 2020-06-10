using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para CU44.xaml
    /// </summary>
    public partial class CU44 : VentanaCtrolEvento
    {
        private Modelo.MiembroComite miembroComite;

        public CU44(Modelo.MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
        }

        private void Click_Aceptar(object sender, RoutedEventArgs e)
        {
            if (ValidarDatos() && NuevaAdscripcion())
            {
                if (!textBlock_mensaje.Text.Equals("Se ha perdido conexión con la base de datos"))
                {
                    textBlock_mensaje.Text = String.Empty;
                    var bold = new Bold(new Run("Adscripción registrada con éxito"));
                    textBlock_mensaje.Inlines.Add(bold);
                }
                textBox_nombre.Text = "";
                textBox_direccion.Text = "";
                textBox_email.Text = "";
                textBox_ciudad.Text = "";
                textBox_estado.Text = "";
            }
            else
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run(
                    "Hay datos inválidos o incompletos, favor de revisar"
                    )
                { Foreground = Brushes.Red });
                textBlock_mensaje.Inlines.Add(bold);
            }
        }

        private bool NuevaAdscripcion()
        {
            Adscripcion_Logica adscripcion_Logica = new Adscripcion_Logica();
            if (!adscripcion_Logica.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Se ha perdido conexión con la base de datos")
                {
                    Foreground = Brushes.Red
                });
                textBlock_mensaje.Inlines.Add(bold);
                return true;
            }
            Modelo.Adscripcion nuevaAdscripcion = new Modelo.Adscripcion();
            nuevaAdscripcion.nombre = textBox_nombre.Text;
            nuevaAdscripcion.correoElectronico = textBox_email.Text;
            nuevaAdscripcion.ciudad = textBox_ciudad.Text;
            nuevaAdscripcion.estado = textBox_estado.Text;
            nuevaAdscripcion.direccion = textBox_direccion.Text;
            return adscripcion_Logica.RegistrarAdscripcion(nuevaAdscripcion);
        }

        private bool ValidarDatos()
        {
            if (textBox_ciudad.Text.Any(char.IsPunctuation) |
                textBox_estado.Text.Any(char.IsPunctuation))
            {
                return false;
            }
            if (textBox_ciudad.Text.Any(char.IsDigit) |
                textBox_estado.Text.Any(char.IsDigit))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox_nombre.Text) |
                string.IsNullOrWhiteSpace(textBox_email.Text) |
                string.IsNullOrWhiteSpace(textBox_ciudad.Text) |
                string.IsNullOrWhiteSpace(textBox_estado.Text) |
                string.IsNullOrWhiteSpace(textBox_direccion.Text))
            {
                return false;
            }
            if (!Regex.IsMatch(textBox_email.Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                return false;
            }
            return true;
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            GestionMiembroComite gestionMiembroComite =
                new GestionMiembroComite(this.miembroComite, 5);
            gestionMiembroComite.Show();
            this.Close();
        }
    }
}
