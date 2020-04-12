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
    public partial class CU10 : Window {

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
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
            }
            else
            {
                if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
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
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
            }
            else
            {
                if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                {
                }
                else
                {
                    e.Handled = true;
                }
            }

        }

        private void textbox_Espacio_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void click_Aceptar(object sender, RoutedEventArgs e)
        {
            if (validarDatos() && nuevoComite())
            {
                /*textBlock_Mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Patrocinador registrado con éxito"));
                textBlock_Mensaje.Inlines.Add(bold);
                button_Cancelar.Content = "Regresar";
                button_Aceptar.Visibility = Visibility.Hidden;
                textbox_Nombre.IsEnabled = false;
                textbox_ApellidoP.IsEnabled = false;
                textbox_ApellidoM.IsEnabled = false;
                textbox_Empresa.IsEnabled = false;
                textbox_Direccion.IsEnabled = false;
                textbox_CorreoE.IsEnabled = false;
                textbox_NumeroTel.IsEnabled = false;*/
            }
            else
            {
                textBlock_Mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Hay datos inválidos o el patrocinador ya existe, favor de revisar") { Foreground = Brushes.Red });
                textBlock_Mensaje.Inlines.Add(bold);
            }
        }

        private bool nuevoComite()
        {
            //Patrocinador nuevoPatrocinador = new Patrocinador();
            return true;
        }

        private bool validarDatos()
        {
            /*if (textbox_Nombre.Text.Any(char.IsPunctuation) | textbox_ApellidoP.Text.Any(char.IsPunctuation) |
                textbox_ApellidoM.Text.Any(char.IsPunctuation) | textbox_Nombre.Text.Any(char.IsDigit) | 
                textbox_ApellidoP.Text.Any(char.IsDigit) | textbox_ApellidoM.Text.Any(char.IsDigit))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(textbox_CorreoE.Text) | string.IsNullOrWhiteSpace(textbox_NumeroTel.Text) |
                textbox_NumeroTel.Text.Any(char.IsLetter) | textbox_NumeroTel.Text.Any(char.IsPunctuation))
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
