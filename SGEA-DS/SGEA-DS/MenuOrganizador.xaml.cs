using Modelo;
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
    /// Lógica de interacción para MenuOrganizador.xaml
    /// </summary>
    public partial class MenuOrganizador : Window
    {
        public MenuOrganizador()
        {
            InitializeComponent();
        }

        private void Click_CerrarSesion(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Click_GestionEvento(object sender, RoutedEventArgs e)
        {
            GestionEvento gestionEvento = new GestionEvento();
            gestionEvento.Show();
            this.Close();
        }

        private void Click_GestionPatrocinadores(object sender, RoutedEventArgs e)
        {
            GestionPatrocinador gestionPatrocinador = new GestionPatrocinador();
            gestionPatrocinador.Show();
            this.Close();
        }

        private void Click_ModificarContrasena(object sender, RoutedEventArgs e)
        {
            CambiarContrasenia cambiarContrasenia = 
                new CambiarContrasenia(new MiembroComite());
            cambiarContrasenia.Show();
            this.Close();
        }
    }
}
