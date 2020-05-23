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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Modelo;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para CU38_2.xaml
    /// </summary>
    public partial class CU38_2 : UserControl
    {

        public CU38_2()
        {
            InitializeComponent();
        }

        public CU38_2(Modelo.Patrocinador patrocinador)
        {
            InitializeComponent();
            llenarGrid(patrocinador);
        }

        private void llenarGrid(Modelo.Patrocinador patrocinador)
        {
            empresa.Content = patrocinador.empresa;
            nombre.Content = patrocinador.nombre;
            apellidoPaterno.Content = patrocinador.apellidoPaterno;
            apellidoMaterno.Content = patrocinador.apellidoMaterno;
            direccion.Content = patrocinador.direccion;
            numeroTelefonico.Content = patrocinador.numeroTelefono;
            correoElectronico.Content = patrocinador.correoElectronico;
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CU38());
        }
    }
}
