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
using SGEA_DS;
using Controlador;
using Logica;

namespace Controlador
{

    public partial class CU01_2 : Window
    {
        private int comiteId;
        private List<MiembroComite> listaMCNoLider;
        private bool handle = true;
        private List<TextBox> listaTBSinNum;
        private List<TextBox> listaTBSinEspacio;
        private MiembroComiteDAO miembroComiteDAO;

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
            }
            else
            {
                textBlock_Mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Hay datos inválidos, favor de revisar")
                {
                    Foreground = Brushes.Red
                });
                textBlock_Mensaje.Inlines.Add(bold);
            }
        }

        private bool guardarMComite()
        {
            MiembroComite nuevoMLComite;
            if (combobox_MiembroC.SelectedIndex <= -1)
            {
                nuevoMLComite = new MiembroComite()
                {
                    nombre = textbox_Nombre.Text,
                    apellidoPaterno = textbox_ApellidoP.Text,
                    apellidoMaterno = textbox_ApellidoM.Text,
                    correoElectronico = textbox_CorreoE.Text,
                    nivelExperiencia = (string)((ComboBoxItem)combobox_NivelE.SelectedValue).Content,
                    nombreUsuario = textbox_Usuario.Text,
                    contrasenia = textbox_Contrasena.Text,
                    evaluador = false,
                    liderComite = true,
                    ComiteId = comiteId
                };
                try
                {
                    miembroComiteDAO.RegistrarMCLider(nuevoMLComite);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            else
            {
                nuevoMLComite = new MiembroComite()
                {
                    nombre = textbox_Nombre.Text,
                    apellidoPaterno = textbox_ApellidoP.Text,
                    apellidoMaterno = textbox_ApellidoM.Text,
                    nombreUsuario = textbox_Usuario.Text,
                    contrasenia = textbox_Contrasena.Text,
                    ComiteId = comiteId
                };
                foreach (MiembroComite miembro in listaMCNoLider)
                {
                    if (combobox_MiembroC.SelectedItem.ToString().Equals(
                            miembro.nombre + " " + miembro.apellidoPaterno))
                    {
                        miembroComiteDAO.ActualizarMCLider(nuevoMLComite);
                    }
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

        public CU01_2(int comiteId)
        {
            this.comiteId = comiteId;
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
            miembroComiteDAO = new MiembroComiteDAO();
            listaMCNoLider = miembroComiteDAO.RecuperarMCNoLider();
            
            foreach (MiembroComite miembro in listaMCNoLider)
            {
                combobox_MiembroC.Items.Add(miembro.nombre + " " + miembro.apellidoPaterno);
            }
        }

        private void llenarTextBox()
        {
            if (combobox_MiembroC.SelectedIndex > -1)
            {
                foreach (MiembroComite miembro in listaMCNoLider)
                {
                    if (combobox_MiembroC.SelectedItem.ToString().Equals(
                        miembro.nombre + " " + miembro.apellidoPaterno))
                    {
                        textbox_Nombre.Text = miembro.nombre;
                        textbox_Nombre.IsReadOnly = true;
                        textbox_ApellidoP.Text = miembro.apellidoPaterno;
                        textbox_ApellidoP.IsReadOnly = true;
                        textbox_ApellidoM.Text = miembro.apellidoMaterno;
                        textbox_ApellidoM.IsReadOnly = true;
                        textbox_CorreoE.Text = miembro.correoElectronico;
                        textbox_CorreoE.IsReadOnly = true;
                        combobox_NivelE.Text = miembro.nivelExperiencia;
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
