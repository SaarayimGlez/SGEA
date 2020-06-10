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
    /// Lógica de interacción para MenuMiembroComite.xaml
    /// </summary>
    public partial class MenuMiembroComite : Window
    {
        private Modelo.MiembroComite miembroComite;

        public MenuMiembroComite(Modelo.MiembroComite miembroComite)
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

        private void Click_GenerarDiplomaGafete(object sender, RoutedEventArgs e)
        {
            CU21 generarDiplomaGafete = new CU21(this.miembroComite);
            generarDiplomaGafete.Show();
            this.Close();
        }

        private void Click_Participantes(object sender, RoutedEventArgs e)
        {
            GestionMiembroComite gestionMiembroComite =
                new GestionMiembroComite(this.miembroComite, 4);
            gestionMiembroComite.Show();
            this.Close();
        }

        private void Click_Asistentes(object sender, RoutedEventArgs e)
        {
            GestionMiembroComite gestionMiembroComite =
                new GestionMiembroComite(this.miembroComite, 2);
            gestionMiembroComite.Show();
            this.Close();
        }

        private void Click_Magistrales(object sender, RoutedEventArgs e)
        {
            GestionMiembroComite gestionMiembroComite =
                new GestionMiembroComite(this.miembroComite, 3);
            gestionMiembroComite.Show();
            this.Close();
        }

        private void Click_Adscripciones(object sender, RoutedEventArgs e)
        {
            GestionMiembroComite gestionMiembroComite =
                new GestionMiembroComite(this.miembroComite, 5);
            gestionMiembroComite.Show();
            this.Close();
        }

        private void Click_ModificarContrasena(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
