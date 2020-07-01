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

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para ConsultaDatosPersonales.xaml
    /// </summary>
    public partial class ConsultaDatosPersonales : Window
    {
        private Evento evento;

        public ConsultaDatosPersonales(Modelo.Evento evento)
        {
            InitializeComponent();
            this.evento = evento;
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            GestionEvento_2 gestionEvento_2 = new GestionEvento_2(this.evento);
            gestionEvento_2.Show();
            this.Close();
        }

        private void Click_ConsultarMagistrales(object sender, RoutedEventArgs e)
        {
            /*Eventos eventos = new Eventos(37);
            eventos.Show();
            this.Close();*/
        }

        private void Click_ConsultarParticipantes(object sender, RoutedEventArgs e)
        {
            ConsultarParticipante consultarParticipante = 
                new ConsultarParticipante(this.evento);
            consultarParticipante.Show();
            this.Close();

        }
    }
}
