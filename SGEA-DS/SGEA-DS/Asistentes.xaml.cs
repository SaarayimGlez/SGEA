﻿using System.Linq;
using System.Windows;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para Asistentes.xaml
    /// </summary>
    public partial class Asistentes: Window {
        /*private Actividad actividad;
        private int ACCION_ASISTENTES = 13;

        public Actividad Actividad { get => actividad;
            set { actividad = value;
                CargarDatos();
            }
        }

        private void CargarDatos() {
            using (var container = new DataModelContainer()) {
                var asistentes = (from asistente in container.AsistenteSet
                                   orderby asistente.Id
                                   select actividad).ToList();
                LBAsistentes.ItemsSource = asistentes;
            }
        }
        */
        public Asistentes() {
            InitializeComponent();
        }
        /*
        private void TerminarConsulta(object sender,RoutedEventArgs e) {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void MostrarDetalles(object sender,RoutedEventArgs e) {
            if (LBAsistentes.SelectedItem != null) {
                DetallesAsistente detalles = new DetallesAsistente();
                detalles.AsistenteMostrado = (Asistente)LBAsistentes.SelectedItem;
                detalles.AsistentesVentana = this;
                detalles.Show();
                this.Hide();
            }
        }

        private void RegresarVentana(object sender,RoutedEventArgs e) {
            Eventos eventos = new Eventos(ACCION_ASISTENTES);
            eventos.Show();
            this.Close();
        }*/
    }
}
