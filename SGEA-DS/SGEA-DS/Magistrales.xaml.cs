using System.Windows;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para Magistrales.xaml
    /// </summary>
    public partial class Magistrales: Window {
        /*private Evento evento;
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
        }*/
        public Magistrales()
        {
            InitializeComponent();
        }
    }
}
