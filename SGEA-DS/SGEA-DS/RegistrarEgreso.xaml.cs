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
    public partial class CU10 : VentanaCtrolEvento
    {

        public CU10()
        {
            InitializeComponent();
        }
        
        private void Click_Aceptar(object sender, RoutedEventArgs e)
        {
            if (ValidarDatos() && NuevoEgreso())
            {
                if (!textBlock_mensaje.Text.Equals("Se ha perdido conexión con la base de datos"))
                {
                    textBlock_mensaje.Text = String.Empty;
                    var bold = new Bold(new Run("Egreso registrado con éxito"));
                    textBlock_mensaje.Inlines.Add(bold);
                }
                button_cancelar.Content = "Regresar";
                button_aceptar.Visibility = Visibility.Hidden;
                textBox_concepto.IsEnabled = false;
                textBox_fecha.IsEnabled = false;
                textBox_monto.IsEnabled = false;
                if (textBox_tipo.IsVisible)
                {
                    textBox_tipo.IsEnabled = false;
                    textBox_costo.IsEnabled = false;
                    textBox_cantidad.IsEnabled = false;
                    checkBox_material.IsEnabled = false;
                }
            }
            else
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(
                    new Run("Hay datos inválidos, favor de revisar")
                    {
                        Foreground = Brushes.Red
                    });
                textBlock_mensaje.Inlines.Add(bold);
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!textBox_cantidad.Text.Equals("") && !textBox_costo.Text.Equals(""))
            {
                int numCamtidad;
                double numCosto;
                int.TryParse(textBox_cantidad.Text, out numCamtidad);
                double.TryParse(textBox_costo.Text, 
                    NumberStyles.AllowDecimalPoint, 
                    NumberFormatInfo.InvariantInfo, 
                    out numCosto);
                double total = numCamtidad * numCosto;
                textBox_monto.Text = total.ToString().Replace(',', '.');
            }
        }

        private bool NuevoEgreso()
        {
            Egreso nuevoEgreso = new Egreso()
            {
                concepto = textBox_concepto.Text,
                fecha = Convert.ToDateTime(textBox_fecha.Text),
                monto = float.Parse(textBox_monto.Text, NumberFormatInfo.InvariantInfo)
            };
            Egreso_Logica egreso_Logica = new Egreso_Logica();
            if (!egreso_Logica.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Se ha perdido conexión con la base de datos")
                {
                    Foreground = Brushes.Red
                });
                textBlock_mensaje.Inlines.Add(bold);
                return true;
            }
            egreso_Logica.RegistrarEgreso(nuevoEgreso);
            if (textBox_tipo.IsVisible)
            {
                Material nuevoMaterial = new Material()
                {
                    cantidad = int.Parse(textBox_cantidad.Text),
                    costo = double.Parse(textBox_costo.Text, NumberFormatInfo.InvariantInfo),
                    tipo = textBox_tipo.Text
                };
                Material_Logica material_Logica = new Material_Logica();
                material_Logica.RegistrarMaterial(
                    nuevoMaterial, 
                    egreso_Logica.RecuperarEgreso().Last().Id);
            }
            return true;
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(textBox_monto.Text) || 
                string.IsNullOrWhiteSpace(textBox_fecha.Text) || 
                string.IsNullOrEmpty(textBox_concepto.Text))
            { 
                return false;
            }
            if (textBox_tipo.IsVisible)
            {
                if (string.IsNullOrWhiteSpace(textBox_cantidad.Text) ||
                string.IsNullOrWhiteSpace(textBox_costo.Text) ||
                string.IsNullOrEmpty(textBox_tipo.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            GestionEgreso gestionEgreso = new GestionEgreso();
            gestionEgreso.Show();
            this.Close();
        }

    }
}
