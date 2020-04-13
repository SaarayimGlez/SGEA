using Logica;
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
    public partial class CU10 : Window
    {

        public CU10()
        {
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

        private void textbox_Numerico_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Shift)
            {
                e.Handled = true;
            }
            else
            {
                if ((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                       (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
                {
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void textbox_NumDinero_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if ((!textBox.Text.Equals("") &&
                textBox.Text.Contains(".") &&
                (e.Key == Key.OemPeriod)) ||
                (Keyboard.Modifiers == ModifierKeys.Shift))
            {
                e.Handled = true;
            }
            else
            {
                if ((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                       (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) ||
                       (e.Key == Key.OemPeriod))
                {
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void DataPicker_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void click_Aceptar(object sender, RoutedEventArgs e)
        {
            if (validarDatos() && nuevoComite())
            {
                textBlock_Mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Egreso registrado con éxito"));
                textBlock_Mensaje.Inlines.Add(bold);
                button_Cancelar.Content = "Regresar";
                button_Aceptar.Visibility = Visibility.Hidden;
                textbox_Concepto.IsEnabled = false;
                textbox_Fecha.IsEnabled = false;
                textbox_Monto.IsEnabled = false;
                if (textbox_Tipo.IsVisible)
                {
                    textbox_Tipo.IsEnabled = false;
                    textbox_Costo.IsEnabled = false;
                    textbox_Cantidad.IsEnabled = false;
                    checkbox_Material.IsEnabled = false;
                }
            }
            else
            {
                textBlock_Mensaje.Text = String.Empty;
                var bold = new Bold(
                    new Run("Hay datos inválidos, favor de revisar")
                    {
                        Foreground = Brushes.Red
                    });
                textBlock_Mensaje.Inlines.Add(bold);
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (!textbox_Cantidad.Text.Equals("") && !textbox_Costo.Text.Equals(""))
            {
                int numCamtidad;
                double numCosto;
                int.TryParse(textbox_Cantidad.Text, out numCamtidad);
                double.TryParse(textbox_Costo.Text, 
                    NumberStyles.AllowDecimalPoint, 
                    NumberFormatInfo.InvariantInfo, 
                    out numCosto);
                double total = numCamtidad * numCosto;
                textbox_Monto.Text = total.ToString().Replace(',', '.');
            }
        }

        private bool nuevoComite()
        {
            Egreso nuevoEgreso = new Egreso()
            {
                concepto = textbox_Concepto.Text,
                fecha = Convert.ToDateTime(textbox_Fecha.Text),
                monto = float.Parse(textbox_Monto.Text, NumberFormatInfo.InvariantInfo)
            };
            Egreso_Logica egreso_Logica = new Egreso_Logica();
            egreso_Logica.RegistrarEgreso(nuevoEgreso);
            if (textbox_Tipo.IsVisible)
            {
                Material nuevoMaterial = new Material()
                {
                    cantidad = int.Parse(textbox_Cantidad.Text),
                    costo = double.Parse(textbox_Costo.Text, NumberFormatInfo.InvariantInfo),
                    tipo = textbox_Tipo.Text
                };
                Material_Logica material_Logica = new Material_Logica();
                material_Logica.RegistrarMaterial(
                    nuevoMaterial, 
                    egreso_Logica.RecuperarEgreso().Last().Id);
            }
            return true;
        }

        private bool validarDatos()
        {
            if (string.IsNullOrWhiteSpace(textbox_Monto.Text) || 
                string.IsNullOrWhiteSpace(textbox_Fecha.Text) || 
                string.IsNullOrEmpty(textbox_Concepto.Text))
            { 
                return false;
            }
            if (textbox_Tipo.IsVisible)
            {
                if (string.IsNullOrWhiteSpace(textbox_Cantidad.Text) ||
                string.IsNullOrWhiteSpace(textbox_Costo.Text) ||
                string.IsNullOrEmpty(textbox_Tipo.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private void click_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Close();
        }

    }
}
