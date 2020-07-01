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
using System.Windows.Shapes;
using Logica;
using Modelo;

namespace SGEA_DS {
    /// <summary>
    /// Lógica de interacción para RegistrarActividad_2.xaml
    /// </summary>
    public partial class RegistrarActividad_2 : Window {

        private int idActividad;
        private Evento evento;

        public RegistrarActividad_2(int idActividad, Evento evento)
        {
            InitializeComponent();
            this.idActividad = idActividad;
            this.evento = evento;
        }

        private bool comprobarCampos()
        {
            if (textBox_Fecha.Text == "" || textBox_HoraFin.Text == "" || TextBox_HoraInicio.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            GestionActividades gestionActividades = new GestionActividades(this.evento);
            gestionActividades.Show();
            this.Close();
        }

        private void Button_Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (comprobarCampos() == false)
            {
                label_Mensaje.Content = "Favor de completar todos los campos";
            }
            else
            {
                Calendario_Logica calendario = new Calendario_Logica();
                if (!calendario.ComprobarConexion())
                {
                    label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
                }
                else
                {
                    try
                    {
                        DateTime fecha = DateTime.Parse(textBox_Fecha.Text);
                        TimeSpan horaInicio = TimeSpan.Parse(TextBox_HoraInicio.Text);
                        TimeSpan horaFin = TimeSpan.Parse(textBox_HoraFin.Text);
                        Calendario calendarioN = new Calendario();
                        calendarioN.actividadId = idActividad;
                        calendarioN.fecha = fecha;
                        calendarioN.horaFin = horaFin;
                        calendarioN.horaInicio = horaInicio;
                        calendarioN.actividadId = idActividad;
                        calendario.RegistrarCalendario(calendarioN);
                        label_Mensaje.Content = "Se ha agregado el horario con exito";
                        textBlock_dias.Text = textBlock_dias.Text + textBox_Fecha.Text + " " + TextBox_HoraInicio.Text + " " + textBox_HoraFin.Text;

                    }
                    catch(FormatException exception)
                    {
                        label_Mensaje.Content = "Datos incorrectos";
                    }
                }
            }
        }
    }
}
