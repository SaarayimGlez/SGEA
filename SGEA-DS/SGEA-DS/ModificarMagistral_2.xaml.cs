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
        private Modelo.Magistral magistralModificar;
        private Modelo.MiembroComite miembroComite;

        public CU18_2(Magistral magistralOriginal, Modelo.MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
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

                textbox_nombre.Text = magistralModificar.nombre;
                textbox_apellidoP.Text = magistralModificar.apellidoPaterno;
                textbox_apellidoM.Text = magistralModificar.apellidoMaterno;

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

            return magistral_Logica.ModificarMagistral(magistralActualizado);
        }

        private void AgregarTextBox()
        {
            listaTextBox = new List<TextBox>();
            listaTextBox.Add(textbox_nombre);
            listaTextBox.Add(textbox_apellidoP);
            listaTextBox.Add(textbox_apellidoM);
        }

        private bool ValidarDatos()
        {
            for (int i = 0; i < 3; i++)
            {
                if (listaTextBox[i].Text.Any(char.IsDigit) || 
                    listaTextBox[i].Text.Any(char.IsPunctuation))
                {
                    return false;
                }
            }
            foreach (TextBox textBox in listaTextBox)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text) && 
                    textBox != textbox_apellidoM)
                {
                    return false;
                }
            }
            return true;
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            GestionMiembroComite gestionMiembroComite =
                new GestionMiembroComite(this.miembroComite, 3);
            gestionMiembroComite.Show();
            var window = Window.GetWindow(this);
            window.Close();
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CU18_1(this.miembroComite));
        }
    }
}
