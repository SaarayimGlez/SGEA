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
using SGEA_DS.Datos;

namespace SGEA_DS.Patrocinadores
{
    /// <summary>
    /// Lógica de interacción para Patrocinadores.xaml
    /// </summary>
    public partial class Patrocinadores : Window
    {
        public Patrocinadores()
        {
            InitializeComponent();
        }

        private void CargarDatos() {
            DataContainer1 data = new DataContainer1();
            List<Patrocinador> patrocinadores = new List<Patrocinador>();
        }
    }
}
