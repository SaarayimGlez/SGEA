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
using Modelo;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para _41_2.xaml
    /// </summary>
    public partial class CU41_2 : UserControl
    {
        private MiembroComite miembroComite;

        public CU41_2()
        {
            InitializeComponent();
        }

        public CU41_2(List<string> autor, MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            llenarGrid(autor);
        }

        private void llenarGrid(List<string> autor)
        {
            nombre.Content = autor[0];
            apellidoPaterno.Content = autor[1];
            apellidoMaterno.Content = autor[2];
            correoElectronico.Content = autor[3];
            articulo.Content = autor[4];
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CU41(this.miembroComite));
        }
    }
}
