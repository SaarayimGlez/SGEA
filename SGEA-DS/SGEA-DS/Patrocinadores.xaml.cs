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
using DataAccess;

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
            CargarDatos();
        }

        private void CargarDatos() {
                using (var container = new DataModelContainer()) {
                    var patrocinadores = (from patrocinador in container.PatrocinadorSet
                                        orderby patrocinador.Id
                                        select patrocinador).ToList();
                LBpatrocinadores.ItemsSource = patrocinadores;
                }
        }

        private void MandarAModificar(object sender,MouseButtonEventArgs e) {
            if (LBpatrocinadores.SelectedItem != null) {
                ModificarPatrocinador modificar = new ModificarPatrocinador();
                modificar.Editable = (Patrocinador)LBpatrocinadores.SelectedItem;
                modificar.Show();
                this.Close();
            }
        }
    }
}
