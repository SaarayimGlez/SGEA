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
    /// Lógica de interacción para ConsultarParticipante.xaml
    /// </summary>
    public partial class ConsultarParticipante : Window {

        private List<Modelo.Participante> listaParticipantes;
        private Evento evento;

        public ConsultarParticipante(Evento evento)
        {
            InitializeComponent();
            LlenarCombobox();
            this.evento = evento;
        }

        private void LlenarCombobox()
        {
            Participante_Logica participante_Logica = new Participante_Logica();
            if (!participante_Logica.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listaParticipantes = participante_Logica.RecuperarParticipante();
                foreach (Participante participanteN in listaParticipantes)
                {
                    combobox_Participante.Items.Add(participanteN.nombre);
                }
            }
        }

        private void Button_Siguiente_Click(object sender, RoutedEventArgs e)
        {
            if (combobox_Participante.Text == "")
            {
                label_Mensaje.Content = "Seleccione un participante";
            }
            else
            {
                String nombre= listaParticipantes[combobox_Participante.SelectedIndex].nombre;
                String paterno = listaParticipantes[combobox_Participante.SelectedIndex].apellidoPaterno;
                String materno = listaParticipantes[combobox_Participante.SelectedIndex].apellidoMaterno;
                String titulo = listaParticipantes[combobox_Participante.SelectedIndex].titulo;
                int idA = listaParticipantes[combobox_Participante.SelectedIndex].AdscripcionId;
                ConsultarParticipante_2 participante2 = new ConsultarParticipante_2(nombre, paterno, materno, titulo, idA, this.evento);
                participante2.Show();
                this.Close();
            }
        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            ConsultaDatosPersonales consultaDatosPersonales =
                new ConsultaDatosPersonales(this.evento);
            consultaDatosPersonales.Show();
            this.Close();
        }
    }
}
