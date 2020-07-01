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
    /// Lógica de interacción para GestionAutorArticulo.xaml
    /// </summary>
    public partial class GestionAutorArticulo : Window
    {
        private Modelo.MiembroComite miembroComite;

        public GestionAutorArticulo(Modelo.MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            MenuLiderComite gestionLiderComite = new MenuLiderComite(this.miembroComite);
            gestionLiderComite.Show();
            this.Close();
        }

        private void Click_RegistrarArticulo(object sender, RoutedEventArgs e)
        {
            CU29 registrarArticulo = new CU29(this.miembroComite);
            registrarArticulo.Show();
            this.Close();
        }

        private void Click_RegistrarAutor(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Click_AsignarArticulo(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Click_ModificarAutor(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Click_RegistrarPago(object sender, RoutedEventArgs e)
        {
            RegistrarPagoArticulo registrarPagoArticulo =
                new RegistrarPagoArticulo(this.miembroComite);
            registrarPagoArticulo.Show();
            this.Close();
        }

        private void Click_ConsultarAutor(object sender, RoutedEventArgs e)
        {
            VentanaUserControl consultarAutor =
                new VentanaUserControl(41, this.miembroComite);
            consultarAutor.Show();
            this.Close();
        }
    }
}
