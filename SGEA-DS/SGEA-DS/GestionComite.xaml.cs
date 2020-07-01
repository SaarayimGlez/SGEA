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

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para GestionComite.xaml
    /// </summary>
    public partial class GestionComite : Window
    {
        private Modelo.Evento evento;

        public GestionComite(Modelo.Evento evento)
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

        private void Click_RegistrarLider(object sender, RoutedEventArgs e)
        {
            VentanaUserControl asignarLiderComite =
                new VentanaUserControl(this.evento);
            asignarLiderComite.Show();
            this.Close();
        }

        private void Click_Registrar(object sender, RoutedEventArgs e)
        {
            CU04 registroComite = new CU04(this.evento);
            registroComite.Show();
            this.Close();
        }

        private void Click_Consultar(object sender, RoutedEventArgs e)
        {
            ConsultarComite consultarComite =
                new ConsultarComite(this.evento);
            consultarComite.Show();
            this.Close();
        }
    }
}
