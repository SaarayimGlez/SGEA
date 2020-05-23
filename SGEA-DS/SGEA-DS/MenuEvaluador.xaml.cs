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
    /// Lógica de interacción para MenuEvaluador.xaml
    /// </summary>
    public partial class MenuEvaluador : Window
    {
        private Modelo.MiembroComite miembroComite;

        public MenuEvaluador(Modelo.MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
        }

        private void Click_CerrarSesion(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Click_RegistrarEvaluacion(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Click_ModificarEvaluacion(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Click_EnviarEvaluacion(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Click_ModificarContrasena(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
