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
    /// Lógica de interacción para GenerarReporteIngresosActividad.xaml
    /// </summary>
    public partial class GenerarReporteIngresosActividad : Window {
        private List<Actividad> listaActividades;
        private Evento evento;

        public GenerarReporteIngresosActividad(Evento evento)
        {
            InitializeComponent();
            this.evento = evento;
            LlenarCombobox();
        }

        private void LlenarCombobox()
        {
            Actividad_Logica actividadLogica = new Actividad_Logica();
            if (!actividadLogica.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listaActividades = actividadLogica.RecuperarListaActividades();
                foreach (Actividad actividadN in listaActividades)
                {
                    combobox_Actividades.Items.Add(actividadN.nombre);
                }
            }
        }

        private void Button_Continuar_Click(object sender, RoutedEventArgs e)
        {
            if (combobox_Actividades.Text == "")
            {
                label_Mensaje.Content = "Seleccione una actividad";
            }
            else
            {
                int idActividad = listaActividades[combobox_Actividades.SelectedIndex].Id;
                GenerarReporteIngresosActividad_2 reporte2 = new GenerarReporteIngresosActividad_2(idActividad);
                reporte2.Show();
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
