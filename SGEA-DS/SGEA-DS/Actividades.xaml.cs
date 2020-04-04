using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataAccess;

namespace SGEA_DS {
    /// <summary>
    /// Lógica de interacción para Actividades.xaml
    /// </summary>
    public partial class Actividades: Window {
        private Evento evento;
        private int centinel;

        public Actividades(Evento evento, int centinela) {
            Evento = evento;
            Centinel = centinela;
            InitializeComponent();
            CargarDatos();
        }

        public Evento Evento { 
            get { return evento; } 
            set { evento = value;
                CargarDatos();
            } 
        }
        public int Centinel { get => centinel; set => centinel = value; }

        private void CargarDatos() {
            using (var container = new DataModelContainer()) {
                var actividades = (from actividad in container.ActividadSet
                                      orderby actividad.Id
                                   where actividad.EventoId == Evento.Id
                                      select actividad).ToList();

                LBActividades.ItemsSource = actividades;
            }
            if(Centinel == 39) {
                BTAceptar.Visibility = Visibility.Visible;
                BTDetalles.Visibility = Visibility.Visible;
                BTRegresar.Visibility = Visibility.Visible;
            }
        }

        private void MostrarAsistentes(object sender,MouseButtonEventArgs e) {
            if(LBActividades.SelectedItem != null) {
                switch (centinel) {
                    case 13:
                        Asistentes asistentes = new Asistentes();
                        asistentes.Actividad = (Actividad)LBActividades.SelectedItem;
                        asistentes.Show();
                        this.Close();
                        break;

                }
            }
        }

        private void TerminarConsulta(object sender,RoutedEventArgs e) {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void MostrarDetalles(object sender,RoutedEventArgs e) {
            if(LBActividades.SelectedItem != null) {
                /*DetallesActividad detalles = new DetallesActividad((Actividad)LBActividades.SelectedItem,this);
                detalles.Show();*/
                this.Close();
            }
        }

        private void RegresarVentana(object sender,RoutedEventArgs e) {
            Eventos eventos = new Eventos(Centinel);
            eventos.Show();
            this.Close();
        }
    }
}
