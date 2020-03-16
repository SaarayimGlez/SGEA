using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Linq;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class CU01_2 : Window
    {
        private string comite;
        private List<MiembroComite> listaMCNoLider;
        private bool handle = true;


        private void textbox_Alfabetico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
            }
            else
            {
                e.Handled = true;
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
            //MessageBox.Show(combobox_MiembroC.SelectedItem.ToString());   
            //MessageBox.Show(((ComboBoxItem)combobox_NivelE.SelectedItem).Content.ToString());
            //MessageBox.Show("Comite: " + this.comite);//esto sucede primero y luego el del .xaml | textbox_Usuario_PreviewKeyDown
            if (validarDatos())
            {
                textBlock_Mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Lider registrado con éxito" + Environment.NewLine + "Usuario: "));
                textBlock_Mensaje.Inlines.Add(bold);
                var normal = new Run(textbox_Usuario.Text + Environment.NewLine);
                textBlock_Mensaje.Inlines.Add(normal);
                bold = new Bold(new Run("Contraseña: "));
                textBlock_Mensaje.Inlines.Add(bold);
                normal = new Run(textbox_Contrasena.Text);
                textBlock_Mensaje.Inlines.Add(normal);
            } else
            {
                textBlock_Mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Hay datos inválidos, favor de revisar") { Foreground = Brushes.Red });
                textBlock_Mensaje.Inlines.Add(bold);
            }
        }

        private bool validarDatos()
        {
            if (combobox_MiembroC.SelectedIndex <= -1)
            {
                if (string.IsNullOrWhiteSpace(textbox_Nombre.Text) | string.IsNullOrWhiteSpace(textbox_ApellidoP.Text) | 
                    string.IsNullOrWhiteSpace(textbox_ApellidoM.Text) | string.IsNullOrWhiteSpace(textbox_CorreoE.Text) |
                    combobox_NivelE.SelectedIndex <= -1)
                {
                    return false;
                }
                if (textbox_Nombre.Text.Any(char.IsDigit) | textbox_ApellidoP.Text.Any(char.IsDigit) | 
                    textbox_ApellidoM.Text.Any(char.IsDigit))
                {
                    return false;
                }
                if (textbox_CorreoE.Text.Any(char.IsWhiteSpace))
                {
                    return false;
                }
            }
            if (textbox_Usuario.Text.Any(char.IsWhiteSpace) | textbox_Contrasena.Text.Any(char.IsWhiteSpace) |
                string.IsNullOrWhiteSpace(textbox_Usuario.Text) | string.IsNullOrWhiteSpace(textbox_Contrasena.Text))
            {
                return false;
            }
            return true;
        }

        private void click_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public CU01_2()
        {
            InitializeComponent();
        }

        public CU01_2(string comiteLider)
        {
            this.comite = comiteLider;
            InitializeComponent();
            llenarComboBox();
        }

        private void llenarComboBox()
        {
            listaMCNoLider = new List<MiembroComite>();
            /**/
            MiembroComite miembroPrueba = new MiembroComite("Jose Miguel", "Martinez", "Rojano", "jmmroj@uv.mx", 2);
            MiembroComite miembroPrueba2= new MiembroComite("Andrea", "Durian", "Hernandez", "aduhe@uv.mx", 3);
            listaMCNoLider.Add(miembroPrueba);
            listaMCNoLider.Add(miembroPrueba2);

            foreach (MiembroComite miembro in listaMCNoLider)
            {
                combobox_MiembroC.Items.Add(miembro.Nombre + " " + miembro.ApellidoPaterno);
            }
            /**/
            
        }

        private void llenarTextBox()
        {
            if (combobox_MiembroC.SelectedIndex > -1)
            {
                foreach (MiembroComite miembro in listaMCNoLider)
                {
                    if (combobox_MiembroC.SelectedItem.ToString().Equals(
                        miembro.Nombre + " " + miembro.ApellidoPaterno))
                    {
                        textbox_Nombre.Text = miembro.Nombre;
                        textbox_Nombre.IsReadOnly = true;
                        textbox_ApellidoP.Text = miembro.ApellidoPaterno;
                        textbox_ApellidoP.IsReadOnly = true;
                        textbox_ApellidoM.Text = miembro.ApellidoMaterno;
                        textbox_ApellidoM.IsReadOnly = true;
                        textbox_CorreoE.Text = miembro.CorreoElectronico;
                        textbox_CorreoE.IsReadOnly = true;
                        combobox_NivelE.SelectedIndex = (miembro.NivelExperiencia - 1);
                        combobox_NivelE.IsEnabled = false;
                    }
                }
            }
        }

        
        private void Combobox_MiembroC_DropDownClosed(object sender, EventArgs e)
        {
            if (handle) llenarTextBox();
            handle = true;
        }

        private void Combobox_MiembroC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            llenarTextBox();
        }
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
