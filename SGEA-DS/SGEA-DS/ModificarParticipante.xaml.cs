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
using Modelo;
using Logica;

namespace SGEA_DS {
    /// <summary>
    /// Lógica de interacción para ModificarParticipante.xaml
    /// </summary>
    public partial class ModificarParticipante : Window {
        private MiembroComite miembroComite;
        private List<Participante> listParticipante;
        private List<Adscripcion> listaAdscripcion;

        public ModificarParticipante(MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            LlenarComboboxParticipante();
            LlenarComboboxAdscripcion();
            OcultarCampos();

        }

        private void OcultarCampos()
        {
            textBox_ApellidoM.IsEnabled = false;
            textBox_ApellidoP.IsEnabled = false;
            textBox_Nombre.IsEnabled = false;
            textBox_Titulo.IsEnabled = false;
            comboBox_Adscripcion.IsEnabled = false;
            button_Guardar.IsEnabled = false;
        }

        private void MostrarCampos()
        {
            textBox_ApellidoM.IsEnabled = true;
            textBox_ApellidoP.IsEnabled = true;
            textBox_Nombre.IsEnabled = true;
            textBox_Titulo.IsEnabled = true;
            comboBox_Adscripcion.IsEnabled = true;
            button_Guardar.IsEnabled = true;
            llenarCampos();
        }

        private void LlenarComboboxAdscripcion()
        {
            Adscripcion_Logica adscripcion = new Adscripcion_Logica();
            if (!adscripcion.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listaAdscripcion = adscripcion.RecuperarListaAdscripcion();
                foreach(Adscripcion adscripcionN in listaAdscripcion)
                {
                    comboBox_Adscripcion.Items.Add(adscripcionN.nombre);
                }
            }
        }

        private void LlenarComboboxParticipante()
        {
            Participante_Logica participante = new Participante_Logica();
            if (!participante.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listParticipante = participante.RecuperarParticipante();
                foreach(Participante participanteN in listParticipante)
                {
                    comboBox_Participante.Items.Add(participanteN.nombre + " " + participanteN.apellidoPaterno + " " + participanteN.apellidoMaterno);
                }
            }
        }

        public bool ValidarCampos()
        {
            if(textBox_Nombre.Text=="" || textBox_ApellidoP.Text == "" || textBox_Titulo.Text == "" || comboBox_Adscripcion.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void Button_Siguiente_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox_Participante.Text=="")
            {
                label_Mensaje.Content = "Favor de elegir una adscripción";
            }
            else
            {
                MostrarCampos();
            }
        }
        //muestra los datos del participante en los campos correspondientes
        private void llenarCampos()
        {
            textBox_Nombre.Text = listParticipante[comboBox_Participante.SelectedIndex].nombre;
            textBox_ApellidoP.Text = listParticipante[comboBox_Participante.SelectedIndex].apellidoPaterno;
            textBox_ApellidoM.Text = listParticipante[comboBox_Participante.SelectedIndex].apellidoMaterno;
            textBox_Titulo.Text = listParticipante[comboBox_Participante.SelectedIndex].titulo;
            foreach(var adscripcion in listaAdscripcion)
            {
                if (adscripcion.Id == listParticipante[comboBox_Participante.SelectedIndex].Id)
                {
                    comboBox_Adscripcion.SelectedItem = adscripcion.nombre;
                }
            }
        }

        private void Button_Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (ComprobarCampos() == false)
            {
                label_Mensaje.Content = "Favor de completar todos los campos";
            }
            else
            {
                Participante_Logica participante = new Participante_Logica();
                participante.ModificarParticipante(listParticipante[comboBox_Participante.SelectedIndex].Id, textBox_Nombre.Text,
                    textBox_ApellidoP.Text, textBox_ApellidoM.Text, textBox_Titulo.Text, 
                    listaAdscripcion[comboBox_Adscripcion.SelectedIndex].Id);

                label_Mensaje.Content = "Se ha modificado el participante con éxito";
            }
        }

        private bool ComprobarCampos()
        {
            if(textBox_ApellidoM.Text=="" || textBox_ApellidoP.Text=="" || textBox_Nombre.Text=="" || textBox_Titulo.Text==""||
                comboBox_Adscripcion.Text=="")
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
            GestionMiembroComite gestion = new GestionMiembroComite(this.miembroComite, 4);
            gestion.Show();
            this.Close();
        }
    }
}
