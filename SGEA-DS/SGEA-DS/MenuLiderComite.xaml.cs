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
    /// Lógica de interacción para GestionLiderComite.xaml
    /// </summary>
    public partial class MenuLiderComite : Window
    {
        private Modelo.MiembroComite miembroComite;

        public MenuLiderComite()
        {
            InitializeComponent();
        }

        public MenuLiderComite(Modelo.MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            if (!miembroComite.evaluador)
            {
                button_gestionArticuloAutor.IsEnabled = false;
                button_gestionArticuloAutor.Visibility = Visibility.Hidden;
            }
        }

        private void Click_CerrarSesion(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Click_RegistrarTarea(object sender, RoutedEventArgs e)
        {
            RegistrarTarea registrarTarea = new RegistrarTarea(this.miembroComite);
            registrarTarea.Show();
            this.Close();
        }

        private void Click_ProgramarReunion(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Click_ArticuloAutor(object sender, RoutedEventArgs e)
        {
            GestionAutorArticulo gestionAutorArticulo = 
                new GestionAutorArticulo(this.miembroComite);
            gestionAutorArticulo.Show();
            this.Close();
        }

        private void Click_MiembrosComite(object sender, RoutedEventArgs e)
        {
            GestionMiembroComite gestionMiembroComite = 
                new GestionMiembroComite(this.miembroComite, 1);
            gestionMiembroComite.Show();
            this.Close();
        }

        private void Click_ModificarContrasena(object sender, RoutedEventArgs e)
        {
            CambiarContrasenia cambiarContrasenia =
                new CambiarContrasenia(this.miembroComite);
            cambiarContrasenia.Show();
            this.Close();
        }
    }
}
