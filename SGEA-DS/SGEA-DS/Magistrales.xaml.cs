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
using DataAccess;

namespace SGEA_DS {
    /// <summary>
    /// Lógica de interacción para Magistrales.xaml
    /// </summary>
    public partial class Magistrales: Window {
        private Evento evento;
        private int ACCION_MAGISTRAL = 37;

        public Magistrales(Evento evento) {
            Evento = evento;
            InitializeComponent();
        }

        public Evento Evento { get => evento; set => evento = value; }

        private void TerminarConsulta(object sender,RoutedEventArgs e) {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void MostrarDetalles(object sender,RoutedEventArgs e) {
            if(LBMagistrales.SelectedItem != null) {
                DetallesMagistral detalles = new DetallesMagistral((Magistral)LBMagistrales.SelectedItem, this);
                detalles.Show();
                this.Close();
            }
        }

        private void RegresarEventos(object sender,RoutedEventArgs e) {
            Eventos eventos = new Eventos(ACCION_MAGISTRAL);
            eventos.Show();
            this.Close();
        }
    }
}
