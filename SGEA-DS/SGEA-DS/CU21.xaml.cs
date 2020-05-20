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
    /// Lógica de interacción para CU21.xaml
    /// </summary>
    public partial class CU21 : Window
    {
        public CU21()
        {
            InitializeComponent();
        }

        private void Click_Descargar(object sender, RoutedEventArgs e)
        {
            Diploma diploma = new Diploma();
            diploma.Show();
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            Gafete gafete = new Gafete("La Chirris");
            gafete.Show();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
