using System;
using System.Windows;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private int eventoId;
        private string nombreEvento;

        public MainWindow()
        {
            InitializeComponent();
            desbloquearBotones();
        }

        public MainWindow(int eventoId, string nombreEvento)
        {
            InitializeComponent();
            this.eventoId = eventoId;
            this.nombreEvento = nombreEvento;
            desbloquearBotones();
        }

        private void desbloquearBotones()
        {
            button_RegistrarLC.IsEnabled = true;
            button_RegistrarC.IsEnabled = true;
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

        private void Button_RegistrarComite(object sender, RoutedEventArgs e)
        {
            CU04 registroComite = new CU04(null);
            registroComite.Show();
            this.Close();
        }

        private void Button_GenerarPrograma(object sender, RoutedEventArgs e)
        {
            CU05 registroComite = new CU05(null);
            registroComite.Show();
            this.Close();
        }

        private void Button_AsignarLiderC(object sender, RoutedEventArgs e)
        {
            VentanaUserControl asignarLiderComite = 
                new VentanaUserControl(null);
            asignarLiderComite.Show();
            this.Close();
        }

        private void Button_RegistrarPatrocinador(object sender, RoutedEventArgs e)
        {
            CU06 registroComite = new CU06();
            registroComite.Show();
            this.Close();
        }

        private void Button_ConsultarPatrocinador(object sender, RoutedEventArgs e)
        {
            /*CU38 consultaPátrocinador = new CU38();
            consultaPátrocinador.Show();
            this.Close();*/
        }
    }
}
