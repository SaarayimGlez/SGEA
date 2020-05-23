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
    /// Lógica de interacción para GestionPatrocinador.xaml
    /// </summary>
    public partial class GestionPatrocinador : Window
    {
        public GestionPatrocinador()
        {
            InitializeComponent();
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            MenuOrganizador menuOrganizador = new MenuOrganizador();
            menuOrganizador.Show();
            this.Close();
        }

        private void Click_Modificar(object sender, RoutedEventArgs e)
        {
            Patrocinadores patrocinadores = new Patrocinadores();
            patrocinadores.Show();
            this.Close();
        }

        private void Click_Registrar(object sender, RoutedEventArgs e)
        {
            CU06 registroPatrocinador = new CU06();
            registroPatrocinador.Show();
            this.Close();
        }

        private void Click_Consultar(object sender, RoutedEventArgs e)
        {
            VentanaUserControl consultarPatrocinador =
                new VentanaUserControl(38);
            consultarPatrocinador.Show();
            this.Close();
        }
    }
}
