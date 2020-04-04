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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SGEA_DS {

    public partial class VentanaPrincipal : Window {

        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void Button_Patrocinador(object sender,RoutedEventArgs e) {
            RegistrarEvento evento = new RegistrarEvento();
            evento.Show();
            this.Close();
        }

        private void Button_Magistral(object sender, RoutedEventArgs e)
        {
            RegistrarEvento evento = new RegistrarEvento();
            evento.Show();
            this.Close();
        }

        private void Button_Evento(object sender, RoutedEventArgs e)
        {
            RegistrarEvento evento = new RegistrarEvento();
            evento.Show();
            this.Close();
        }

    }
}
