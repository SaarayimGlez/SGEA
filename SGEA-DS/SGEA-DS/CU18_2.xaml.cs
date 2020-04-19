using Logica;
using Modelo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace SGEA_DS
{
    public partial class CU18_2 : CtrolUsrCtrolEvento
    {
        private List<TextBox> listaTextBox;
        private Magistral magistralModificar;
        private Adscripcion adscripcionModificar;

        public CU18_2(Magistral magistralOriginal)
        {
            InitializeComponent();
            LlenarCampos(magistralOriginal);
        }

        private void LlenarCampos(Magistral magistralOriginal)
        {
            Adscripcion_Logica adscripcion_Logica = new Adscripcion_Logica();
            if (!adscripcion_Logica.ComprobarConexion())
            {
                textBlock_mensaje.Text = "sin conexion";
                Click_Aceptar(new object(), new RoutedEventArgs());
            }
            else
            {
                this.magistralModificar = magistralOriginal;
                this.adscripcionModificar = 
                    adscripcion_Logica.RecuperarAdscripcion(magistralModificar.AdscripcionId);

                textbox_nombre.Text = magistralModificar.nombre;
                textbox_apellidoP.Text = magistralModificar.apellidoPaterno;
                textbox_apellidoM.Text = magistralModificar.apellidoMaterno;
                textbox_ciudad.Text = adscripcionModificar.ciudad;
                textbox_estado.Text = adscripcionModificar.estado;
                textbox_direccion.Text = adscripcionModificar.direccion;
                textbox_institucion.Text = adscripcionModificar.nombre;
                textbox_email.Text = adscripcionModificar.correoElectronico;

                AgregarTextBox();
            }
        }

        private void Click_Aceptar(object sender, RoutedEventArgs e)
        {
            if (textBlock_mensaje.Text.Equals("sin conexion") || ValidarDatos())
            {
                ModificarEvento();
                if (!textBlock_mensaje.Text.Equals("Se ha perdido conexión con la base de datos"))
                {
                    textBlock_mensaje.Text = String.Empty;
                    var bold = new Bold(new Run("Magistral modificado con éxito"));
                    textBlock_mensaje.Inlines.Add(bold);
                }
                button_cancelar.Content = "Regresar";
                button_aceptar.Visibility = Visibility.Hidden;
                foreach (TextBox textBox in listaTextBox)
                {
                    textBox.IsEnabled = false;
                }
            }
            else
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(
                    new Run("Hay datos inválidos o incompletos, favor de revisar")
                    {
                        Foreground = Brushes.Red
                    });
                textBlock_mensaje.Inlines.Add(bold);
            }
        }
        
        private bool ModificarEvento()
        {
            Magistral_Logica magistral_Logica = new Magistral_Logica();
            if (textBlock_mensaje.Text.Equals("sin conexion") || 
                !magistral_Logica.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                textBlock_mensaje.Text = "Se ha perdido conexión con la base de datos";
                textBlock_mensaje.Foreground = Brushes.Red;
                textBlock_mensaje.FontWeight = FontWeights.Bold;
                return true;
            }

            Magistral magistralActualizado = new Magistral()
            {
                Id = magistralModificar.Id,
                nombre = textbox_nombre.Text,
                apellidoMaterno = textbox_apellidoM.Text,
                apellidoPaterno = textbox_apellidoP.Text
            };

            Adscripcion adscripcionActualizada = new Adscripcion()
            {
                Id = adscripcionModificar.Id,
                ciudad = textbox_ciudad.Text,
                estado = textbox_estado.Text,
                direccion = textbox_direccion.Text,
                nombre = textbox_institucion.Text, 
                correoElectronico = textbox_email.Text
            };

            return magistral_Logica.ModificarMagistral(magistralActualizado, 
                adscripcionActualizada);
        }

        private void AgregarTextBox()
        {
            listaTextBox = new List<TextBox>();
            listaTextBox.Add(textbox_nombre);
            listaTextBox.Add(textbox_apellidoP);
            listaTextBox.Add(textbox_apellidoM);
            listaTextBox.Add(textbox_ciudad);
            listaTextBox.Add(textbox_estado);
            listaTextBox.Add(textbox_direccion);
            listaTextBox.Add(textbox_email);
            listaTextBox.Add(textbox_institucion);
        }

        private bool ValidarDatos()
        {
            for (int i = 0; i < 5; i++)
            {
                if (listaTextBox[i].Text.Any(char.IsDigit) || 
                    listaTextBox[i].Text.Any(char.IsPunctuation))
                {
                    return false;
                }
            }
            foreach (TextBox textBox in listaTextBox)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return false;
                }
            }
            if (!Regex.IsMatch(listaTextBox[6].Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                return false;
            }
            return true;
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.Close();
        }

    }
}
