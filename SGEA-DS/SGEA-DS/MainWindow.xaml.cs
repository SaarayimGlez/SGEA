using System.Windows;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para VentanaPrincipal.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender,RoutedEventArgs e) {
            RegistrarEvento evento = new RegistrarEvento();
            evento.Show();
            this.Close();
        }

        private void Button_Click_1(object sender,RoutedEventArgs e) {
            Patrocinadores patrocinadores = new Patrocinadores();
            patrocinadores.Show();
            this.Close();
        }

        private void Button_Click_2(object sender,RoutedEventArgs e) {
            Eventos eventos = new Eventos(13);
            eventos.Show();
            this.Close();
        }

        private void Button_Click_3(object sender,RoutedEventArgs e) {
            Eventos eventos = new Eventos(37);
            eventos.Show();
            this.Close();
        }

        private void Button_Click_4(object sender,RoutedEventArgs e) {
            Eventos eventos = new Eventos(39);
            eventos.Show();
            this.Close();
        }
    }
}
