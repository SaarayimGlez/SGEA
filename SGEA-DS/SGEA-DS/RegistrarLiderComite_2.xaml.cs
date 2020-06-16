using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Input;
using System.Linq;
using Logica;
using Modelo;

namespace SGEA_DS
{

    public partial class CU01_2 : CtrolUsrCtrolEvento
    {
        private string comite;
        private List<List<string>> listaMCNoLider;
        private bool handle = true;
        private List<TextBox> listaTBSinNum;
        private List<TextBox> listaTBSinEspacio;
        private MiembroComite_Logica miembroComiteDAO;
        private Modelo.Evento evento;

        private void Click_Aceptar(object sender, RoutedEventArgs e)
        {
            if (textBlock_mensaje.Text.Equals("sin conexion") || ValidarDatos())
            {
                GuardarUsuario();
                if (!textBlock_mensaje.Text.Equals("Se ha perdido conexión con la base de datos"))
                {
                    GuardarMComite();
                    textBlock_mensaje.Text = String.Empty;
                    var bold = new Bold(new Run("Lider registrado con éxito" +
                        Environment.NewLine + "Usuario: "));
                    textBlock_mensaje.Inlines.Add(bold);
                    var normal = new Run(textBox_usuario.Text + Environment.NewLine);
                    textBlock_mensaje.Inlines.Add(normal);
                    bold = new Bold(new Run("Contraseña: "));
                    textBlock_mensaje.Inlines.Add(bold);
                    normal = new Run(passwordBox_contrasena.Password);
                    textBlock_mensaje.Inlines.Add(normal);
                }
                button_aceptar.IsEnabled = false;
                comboBox_miembroC.IsEnabled = false;
                comboBox_nivelE.IsEnabled = false;
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
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Hay datos inválidos, favor de revisar")
                {
                    Foreground = Brushes.Red
                });
                textBlock_mensaje.Inlines.Add(bold);
            }
        }

        private bool GuardarUsuario()
        {
            if (miembroComiteDAO.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                textBlock_mensaje.Text = "Se ha perdido conexión con la base de datos";
                textBlock_mensaje.Foreground = Brushes.Red;
                textBlock_mensaje.FontWeight = FontWeights.Bold;
                return true;
            }
            if (comboBox_miembroC.SelectedIndex <= -1)
            {
                Modelo.Usuario nuevoUsuario = new Modelo.Usuario()
                {
                    nombreUsuario = textBox_usuario.Text,
                    contrasenia = passwordBox_contrasena.Password
                };
                Usuario_Logica usuario_Logica = new Usuario_Logica();
                return usuario_Logica.RegistrarUsuario(nuevoUsuario);
            }
            return true;
        }

        private bool GuardarMComite()
        {
            String patronSimbolo = @"\s-\s?[+*]?\s?-\s";
            String[] elementoComite =
                System.Text.RegularExpressions.Regex.Split(comite, patronSimbolo);
            Usuario_Logica usuario_Logica = new Usuario_Logica();
            Modelo.MiembroComite nuevoMLComite = new Modelo.MiembroComite()
            {
                nombre = textBox_nombre.Text,
                apellidoPaterno = textBox_apellidoP.Text,
                apellidoMaterno = textBox_apellidoM.Text,
                evaluador = false,
                ComiteId = Convert.ToInt32(elementoComite[1]),
                correoElectronico = textBox_correoE.Text,
                nivelExperiencia =
                    (string)((ComboBoxItem)comboBox_nivelE.SelectedValue).Content,
                liderComite = true
            };
            if (String.Equals(elementoComite[0], "Comité de evaluación"))
            {
                nuevoMLComite.evaluador = true;
            }
            if (comboBox_miembroC.SelectedIndex > -1)
            {
                foreach (List<string> miembro in listaMCNoLider)
                {
                    if (comboBox_miembroC.SelectedItem.ToString().Equals(
                            miembro[4] + " " + miembro[1]))
                    {
                        return miembroComiteDAO.ActualizarMCLider(
                            nuevoMLComite);
                    }
                }
            }
            return miembroComiteDAO.RegistrarMCLider(
                nuevoMLComite,
                usuario_Logica.RecuperarUsuario().Last().Id);
        }

        private bool ValidarDatos()
        {
            if (comboBox_miembroC.SelectedIndex <= -1)
            {
                foreach (TextBox textBox in listaTBSinNum)
                {
                    if ( (string.IsNullOrWhiteSpace(textBox.Text) && textBox != textBox_apellidoM) |
                        textBox.Text.Any(char.IsDigit) |
                        textBox.Text.Any(char.IsPunctuation))
                    {
                        return false;
                    }
                }
                if (comboBox_nivelE.SelectedIndex <= -1)
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
            if (string.IsNullOrWhiteSpace(passwordBox_contrasena.Password))
            {
                return false;
            }
            return true;
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CU01_1(this.evento));
        }
        
        public CU01_2(string comite, Modelo.Evento evento)
        {
            this.comite = comite;
            this.evento = evento;
            InitializeComponent();
            AgregarTextBox();
            LlenarComboBox();
        }

        private void AgregarTextBox()
        {
            listaTBSinNum = new List<TextBox>();
            listaTBSinEspacio = new List<TextBox>();
            listaTBSinNum.Add(textBox_nombre);
            listaTBSinNum.Add(textBox_apellidoP);
            listaTBSinNum.Add(textBox_apellidoM);
            listaTBSinEspacio.Add(textBox_correoE);
            listaTBSinEspacio.Add(textBox_usuario);
        }

        private void LlenarComboBox()
        {
            miembroComiteDAO = new MiembroComite_Logica();
            if (!miembroComiteDAO.ComprobarConexion())
            {
                textBlock_mensaje.Text = "sin conexion";
                Click_Aceptar(new object(), new RoutedEventArgs());
            }
            else
            {
                listaMCNoLider = miembroComiteDAO.RecuperarMCNoLider(this.evento.Id);

                foreach (List<string> miembro in listaMCNoLider)
                {
                    comboBox_miembroC.Items.Add(miembro[4] + " " + miembro[1]);
                }
            }
        }

        private void LlenarTextBox()
        {
            if (comboBox_miembroC.SelectedIndex > -1)
            {
                foreach (List<string> miembro in listaMCNoLider)
                {
                    if (comboBox_miembroC.SelectedItem.ToString().Equals(
                        miembro[4] + " " + miembro[1]))
                    {
                        textBox_nombre.Text = miembro[4];
                        textBox_nombre.IsReadOnly = true;
                        textBox_apellidoP.Text = miembro[1];
                        textBox_apellidoP.IsReadOnly = true;
                        textBox_apellidoM.Text = miembro[0];
                        textBox_apellidoM.IsReadOnly = true;
                        textBox_correoE.Text = miembro[2];
                        textBox_correoE.IsReadOnly = true;
                        comboBox_nivelE.Text = miembro[3];
                        comboBox_nivelE.IsEnabled = false;
                        textBox_usuario.Text = miembro[5];
                        textBox_usuario.IsReadOnly = true;
                        passwordBox_contrasena.Password = miembro[6];
                        passwordBox_contrasena.Focusable = false;
                        passwordBox_contrasena.IsHitTestVisible = false;
                    }
                }
            }
        }


        private void Combobox_MiembroC_DropDownClosed(object sender, EventArgs e)
        {
            if (handle) LlenarTextBox();
            handle = true;
        }

        private void Combobox_MiembroC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            LlenarTextBox();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
