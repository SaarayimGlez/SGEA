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
using Logica;
using Modelo;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para GenerarReporteIngresosActividad_2.xaml
    /// </summary>
    public partial class GenerarReporteIngresosActividad_2 : Window
    {
        private int actividad;
        public GenerarReporteIngresosActividad_2(int idActividad)
        {
            InitializeComponent();
            this.actividad = idActividad;
        }

        private void Button_Descargar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
