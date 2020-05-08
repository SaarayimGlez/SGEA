﻿using Logica;
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
    public partial class CU15 : VentanaCtrolEvento
    {
        private int eventoId;

        public CU15(/*int idEvento*/)
        {
            InitializeComponent();
            this.eventoId = 1;
            LlenarCampos(eventoId);
        }

        private void LlenarCampos(int idEvento)
        {
            Evento_Logica evento_Logica = new Evento_Logica();
            if (!evento_Logica.ComprobarConexion())
            {
                textBlock_mensaje.Text = "sin conexion";
                Click_Aceptar(new object(), new RoutedEventArgs());
            }
            else
            {
                Evento eventoModificar = evento_Logica.RecuperarEvento(idEvento);

                textBox_nombre.Text = eventoModificar.nombre;
                textBox_lugar.Text = eventoModificar.lugar;
                comboBox_iOrganizadora.Text = eventoModificar.institucionOrganizadora;
                datePicker_fInicio.Text = eventoModificar.fechaInicio.ToString("dd/MM/yyyy");
                datePicker_fFin.Text = eventoModificar.fechaFin.ToString("dd/MM/yyyy");
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
                    var bold = new Bold(new Run("Evento modificado con éxito"));
                    textBlock_mensaje.Inlines.Add(bold);
                }
                button_cancelar.Content = "Regresar";
                button_aceptar.Visibility = Visibility.Hidden;
                textBox_nombre.IsEnabled = false;
                textBox_lugar.IsEnabled = false;
                comboBox_iOrganizadora.IsEnabled = false;
                datePicker_fInicio.IsEnabled = false;
                datePicker_fFin.IsEnabled = false;
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
            Evento_Logica evento_Logica = new Evento_Logica();
            if (textBlock_mensaje.Text.Equals("sin conexion") || 
                !evento_Logica.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                textBlock_mensaje.Text = "Se ha perdido conexión con la base de datos";
                textBlock_mensaje.Foreground = Brushes.Red;
                textBlock_mensaje.FontWeight = FontWeights.Bold;
                return true;
            }

            Evento eventoActualizado = new Evento()
            {
                Id = eventoId,
                nombre = textBox_nombre.Text,
                lugar = textBox_lugar.Text,
                institucionOrganizadora = comboBox_iOrganizadora.Text,
                fechaInicio = Convert.ToDateTime(datePicker_fInicio.Text),
                fechaFin = Convert.ToDateTime(datePicker_fInicio.Text)
            };

            return evento_Logica.ModificarEvento(eventoActualizado);
        }

        private bool ValidarDatos()
        {

            if (string.IsNullOrWhiteSpace(textBox_nombre.Text) || 
                string.IsNullOrWhiteSpace(textBox_lugar.Text) || 
                string.IsNullOrEmpty(datePicker_fInicio.Text) ||
                string.IsNullOrEmpty(datePicker_fInicio.Text))
            { 
                return false;
            }
            return true;
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
