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
        private int comiteId;
        private List<Modelo.MiembroComite> listaMCNoLider;
        private bool handle = true;
        private List<TextBox> listaTBSinNum;
        private List<TextBox> listaTBSinEspacio;
        private MiembroComite_Logica miembroComiteDAO;

        private void Click_Aceptar(object sender, RoutedEventArgs e)
        {
            if (textBlock_mensaje.Text.Equals("sin conexion") || ValidarDatos())
            {
                GuardarMComite();
                if (!textBlock_mensaje.Text.Equals("Se ha perdido conexión con la base de datos"))
                {
                    textBlock_mensaje.Text = String.Empty;
                    var bold = new Bold(new Run("Lider registrado con éxito" +
                        Environment.NewLine + "Usuario: "));
                    textBlock_mensaje.Inlines.Add(bold);
                    var normal = new Run(textBox_usuario.Text + Environment.NewLine);
                    textBlock_mensaje.Inlines.Add(normal);
                    bold = new Bold(new Run("Contraseña: "));
                    textBlock_mensaje.Inlines.Add(bold);
                    normal = new Run(textBox_contrasena.Text);
                    textBlock_mensaje.Inlines.Add(normal);
                }
                button_cancelar.Content = "Regresar";
                button_aceptar.Visibility = Visibility.Hidden;
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

        private bool GuardarMComite()
        {
            if (!miembroComiteDAO.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                textBlock_mensaje.Text = "Se ha perdido conexión con la base de datos";
                textBlock_mensaje.Foreground = Brushes.Red;
                textBlock_mensaje.FontWeight = FontWeights.Bold;
                return true;
            }
            Modelo.MiembroComite nuevoMLComite = new Modelo.MiembroComite()
            {
                nombre = textBox_nombre.Text,
                apellidoPaterno = textBox_apellidoP.Text,
                apellidoMaterno = textBox_apellidoM.Text,
                nombreUsuario = textBox_usuario.Text,
                contrasenia = textBox_contrasena.Text,
                evaluador = false,
                ComiteId = comiteId
            };
            if (comboBox_miembroC.SelectedIndex <= -1)
            {
                nuevoMLComite.correoElectronico = textBox_correoE.Text;
                nuevoMLComite.nivelExperiencia =
                        (string)((ComboBoxItem)comboBox_nivelE.SelectedValue).Content;
                nuevoMLComite.liderComite = true;
            }
            if (comiteId == 1)
            {
                nuevoMLComite.evaluador = true;
            }
            if (comboBox_miembroC.SelectedIndex > -1)
            {
                foreach (Modelo.MiembroComite miembro in listaMCNoLider)
                {
                    if (comboBox_miembroC.SelectedItem.ToString().Equals(
                            miembro.nombre + " " + miembro.apellidoPaterno))
                    {
                        return miembroComiteDAO.ActualizarMCLider(nuevoMLComite);
                    }
                }
            }
            return miembroComiteDAO.RegistrarMCLider(nuevoMLComite);
        }

        private bool ValidarDatos()
        {
            if (comboBox_miembroC.SelectedIndex <= -1)
            {
                foreach (TextBox textBox in listaTBSinNum)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text) | textBox.Text.Any(char.IsDigit) |
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
            return true;
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            GestionComite gestionComite = new GestionComite();
            gestionComite.Show();
            var window = Window.GetWindow(this);
            window.Close();
        }
        
        public CU01_2(int comiteId)
        {
            this.comiteId = comiteId;
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
            listaTBSinEspacio.Add(textBox_contrasena);
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
                listaMCNoLider = miembroComiteDAO.RecuperarMCNoLider();

                foreach (Modelo.MiembroComite miembro in listaMCNoLider)
                {
                    comboBox_miembroC.Items.Add(miembro.nombre + " " + miembro.apellidoPaterno);
                }
            }
        }

        private void LlenarTextBox()
        {
            if (comboBox_miembroC.SelectedIndex > -1)
            {
                foreach (Modelo.MiembroComite miembro in listaMCNoLider)
                {
                    if (comboBox_miembroC.SelectedItem.ToString().Equals(
                        miembro.nombre + " " + miembro.apellidoPaterno))
                    {
                        textBox_nombre.Text = miembro.nombre;
                        textBox_nombre.IsReadOnly = true;
                        textBox_apellidoP.Text = miembro.apellidoPaterno;
                        textBox_apellidoP.IsReadOnly = true;
                        textBox_apellidoM.Text = miembro.apellidoMaterno;
                        textBox_apellidoM.IsReadOnly = true;
                        textBox_correoE.Text = miembro.correoElectronico;
                        textBox_correoE.IsReadOnly = true;
                        comboBox_nivelE.Text = miembro.nivelExperiencia;
                        comboBox_nivelE.IsEnabled = false;
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
