using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Linq;
using DataAccess;

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
        private List<TextBox> listaTBSinNum;
        private List<TextBox> listaTBSinEspacio;
        //private DAOMiembroComite daoMiembroComite;

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

        private void textbox_Espacio_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void click_Aceptar(object sender, RoutedEventArgs e)
        {
            if (validarDatos() && guardarMComite())
            {
                textBlock_Mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Lider registrado con éxito" + 
                    Environment.NewLine + "Usuario: "));
                textBlock_Mensaje.Inlines.Add(bold);
                var normal = new Run(textbox_Usuario.Text + Environment.NewLine);
                textBlock_Mensaje.Inlines.Add(normal);
                bold = new Bold(new Run("Contraseña: "));
                textBlock_Mensaje.Inlines.Add(bold);
                normal = new Run(textbox_Contrasena.Text);
                textBlock_Mensaje.Inlines.Add(normal);
                button_Cancelar.Content = "Regresar";
                button_Aceptar.Visibility = Visibility.Hidden;
                combobox_MiembroC.IsEnabled = false;
                combobox_NivelE.IsEnabled = false;
                foreach (TextBox textBox in listaTBSinNum)
                {
                    textBox.IsEnabled = false;
                }
                foreach (TextBox textBox in listaTBSinEspacio)
                {
                    textBox.IsEnabled = false;
                }
            } else
            {
                textBlock_Mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Hay datos inválidos, favor de revisar") {
                    Foreground = Brushes.Red });
                textBlock_Mensaje.Inlines.Add(bold);
            }
        }

        private bool guardarMComite()
        {
            MiembroComite nuevoMComite;
            if (combobox_MiembroC.SelectedIndex <= -1)
            {//insert into como lider
                nuevoMComite = new MiembroComite();
            } else
            {//update into como lider
                foreach (MiembroComite miembro in listaMCNoLider)
                {
                    //if (combobox_MiembroC.SelectedItem.ToString().Equals(
                        //miembro.Nombre + " " + miembro.ApellidoPaterno))
                    //{
                        //nuevoMComite = new MiembroComite(
                        //    miembro.Nombre, miembro.ApellidoPaterno, miembro.ApellidoMaterno);
                    //}
                }
            }
            return true;
        }

        private bool validarDatos()
        {
            if (combobox_MiembroC.SelectedIndex <= -1)
            {
                foreach (TextBox textBox in listaTBSinNum)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text) | textBox.Text.Any(char.IsDigit) |
                        textBox.Text.Any(char.IsPunctuation))
                    {
                        return false;
                    }
                }
                if (combobox_NivelE.SelectedIndex <= -1)
                {
                    return false;
                }
            }
            foreach (TextBox textBox in listaTBSinEspacio)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text) | textBox.Text.Any(char.IsWhiteSpace))
                {
                    return false;
                }
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
            agregarTextBox();
        }

        private void agregarTextBox()
        {
            listaTBSinNum = new List<TextBox>();
            listaTBSinEspacio = new List<TextBox>();
            listaTBSinNum.Add(textbox_Nombre);
            listaTBSinNum.Add(textbox_ApellidoP);
            listaTBSinNum.Add(textbox_ApellidoM);
            listaTBSinEspacio.Add(textbox_CorreoE);
            listaTBSinEspacio.Add(textbox_Usuario);
            listaTBSinEspacio.Add(textbox_Contrasena);
        }

        private void llenarComboBox()
        {
            //daoMiembroComite = new DAOMiembroComite();
            //listaMCNoLider = daoMiembroComite.GetMCNoLider();
            
            MiembroComite miembroPrueba = new MiembroComite();//"Jose Miguel", "Martinez", "Rojano", "jmmroj@uv.mx", 2
            miembroPrueba.nombre = "Jose Miguel";
            miembroPrueba.apellidoPaterno = "Martinez";
            MiembroComite miembroPrueba2= new MiembroComite();//"Andrea", "Durian", "Hernandez", "aduhe@uv.mx", 3
            miembroPrueba2.nombre = "Andrea";
            miembroPrueba2.apellidoPaterno = "Durian";
            listaMCNoLider.Add(miembroPrueba);
            listaMCNoLider.Add(miembroPrueba2);
            /**/

            foreach (MiembroComite miembro in listaMCNoLider)
            {
                combobox_MiembroC.Items.Add(miembro.nombre + " " + miembro.apellidoPaterno);
            }
            /**/
            
        }

        private void llenarTextBox()
        {
            if (combobox_MiembroC.SelectedIndex > -1)
            {
                foreach (MiembroComite miembro in listaMCNoLider)
                {
                    /*if (combobox_MiembroC.SelectedItem.ToString().Equals(
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
                    }*/
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
