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
    /// Lógica de interacción para GestionActividades.xaml
    /// </summary>
    public partial class GestionActividades : Window
    {
        public GestionActividades()
        {
            InitializeComponent();
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            GestionEvento_2 gestionEvento_2 = new GestionEvento_2();
            gestionEvento_2.Show();
            this.Close();
        }

        private void Click_NumAsistentes(object sender, RoutedEventArgs e)
        {
            Eventos eventos = new Eventos(13);
            eventos.Show();
            this.Close();
        }

        private void Click_Consultar(object sender, RoutedEventArgs e)
        {
            Eventos eventos = new Eventos(39);
            eventos.Show();
            this.Close();
        }

        private void Click_GenerarReporteI(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException(); ;
        }

        private void Click_Registrar(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException(); ;
        }

        private void Click_Modificar(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException(); ;
        }
    }
}
