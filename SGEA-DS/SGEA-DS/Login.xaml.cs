using Logica;
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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Click_Entrar(object sender, RoutedEventArgs e)
        {
            MiembroComite_Logica miembroComite_Logica = new MiembroComite_Logica();
            Modelo.MiembroComite usuarioActual = miembroComite_Logica.RecuperarMiembroComite(1);
            if (usuarioActual != null)
            {
                GestionEvento gestionEvento = new GestionEvento(usuarioActual);
                gestionEvento.Show();
                this.Close();
            }
            else
            {
                MenuOrganizador menuOrganizador = new MenuOrganizador();
                menuOrganizador.Show();
                this.Close();
            }
        }

    }
}
