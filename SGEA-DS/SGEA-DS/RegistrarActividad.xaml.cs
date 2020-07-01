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
    /// Lógica de interacción para RegistrarActividad.xaml
    /// </summary>
    public partial class RegistrarActividad : Window {

        private List<Participante> listaParticipantes;
        private List<Magistral> listaMagistrales;
        private List<Articulo> listaArticulos;
        private Evento evento;

        public RegistrarActividad(Evento evento)
        {
            InitializeComponent();
            this.evento = evento;
            LlenarComboboxArticulo();
            LlenarComboboxMagistral();
            LlenarComboboxParticipante();
        }

        private bool ComprobarCampos()
        {
            if (textBox_Aula.Text == "" || textBox_Costo.Text == "" || textBox_Nombre.Text == "" ||
                textBox_Tipo.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void LlenarComboboxMagistral()
        {
            Magistral_Logica magistralLogica = new Magistral_Logica();
            if (!magistralLogica.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listaMagistrales = magistralLogica.RecuperarMagistral();
                foreach (Magistral magidtralN in listaMagistrales)
                {
                    comboBox_Magistral.Items.Add(magidtralN.nombre + " " + magidtralN.apellidoPaterno +
                        " " + magidtralN.apellidoMaterno);
                }
            }
        }

        private void LlenarComboboxParticipante()
        {
            Participante_Logica partcipanteLogica = new Participante_Logica();
            if (!partcipanteLogica.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listaParticipantes = partcipanteLogica.RecuperarParticipante();
                foreach (Participante participanteN in listaParticipantes)
                {
                    comboBox_Participante.Items.Add(participanteN.nombre + " " + participanteN.apellidoPaterno +
                        " " + participanteN.apellidoMaterno);
                }
            }
        }

        private void LlenarComboboxArticulo()
        {
            Articulo_Logica articulo_Logica = new Articulo_Logica();
            if (!articulo_Logica.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listaArticulos = articulo_Logica.RecuperarArticulo();
                foreach (Articulo articuloN in listaArticulos)
                {
                    combobox_Articulo.Items.Add(articuloN.titulo);
                }
            }
        }

        private void Button_Siguiente_Click(object sender, RoutedEventArgs e)
        {
            if (ComprobarCampos() == false)
            {
                label_Mensaje.Content = "Favor de completar todos los campos";
            }
            else
            {
                Actividad_Logica actividad_Logica = new Actividad_Logica();
                Actividad actividad = new Modelo.Actividad();
                int idMagistral = 0;
                int idParticipante = 0;
                int idArticulo = 0;
                if (comboBox_Magistral.SelectedIndex != -1)
                {
                    idMagistral = listaMagistrales[comboBox_Magistral.SelectedIndex].Id;
                }
                else if (comboBox_Participante.SelectedIndex != -1)
                {
                    idParticipante = listaParticipantes[comboBox_Participante.SelectedIndex].Id;
                }
                else if (combobox_Articulo.SelectedIndex != -1)
                {
                    idArticulo = listaArticulos[combobox_Articulo.SelectedIndex].Id;
                }

                actividad.aula = textBox_Aula.Text;
                try
                {
                    actividad.costo = Convert.ToDouble(textBox_Costo.Text);
                }
                catch (FormatException exception)
                {
                    label_Mensaje.Content = "Datos incorrectos";
                }
                actividad.nombre = textBox_Nombre.Text;
                actividad.tipo = textBox_Tipo.Text;
                actividad.magistralId = idMagistral;
                actividad.participanteId = idParticipante;
                actividad.articuloId = idArticulo;
                actividad.eventoId = this.evento.Id;

                actividad_Logica.RegistrarActividad(actividad);
                int idActividadM = actividad_Logica.RecuperarActividad(textBox_Nombre.Text).Id;
                RegistrarActividad_2 registrarActividad_2 = new RegistrarActividad_2(idActividadM, this.evento);
                registrarActividad_2.Show();
                this.Close();
            }

            
        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            GestionActividades gestionActividades = new GestionActividades(this.evento);
            gestionActividades.Show();
            this.Close();
        }
    }
}
