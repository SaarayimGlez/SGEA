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
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
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
            Eventos eventos = new Eventos();
            eventos.Show();
            this.Close();
        }
    }
}
