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

namespace SGEA_DS {
    /// <summary>
    /// Lógica de interacción para ModificarPatrocinador.xaml
    /// </summary>
    public partial class ModificarPatrocinador: Window {
        private Patrocinador editable;

        public ModificarPatrocinador() {
            InitializeComponent();
        }

        public Patrocinador Editable { 
            get { return editable; }
            set {
                editable = value;
                TBNombre.Text = editable.nombre;
                TBPaterno.Text = editable.apellidoPaterno;
                TBMaterno.Text = editable.apellidoMaterno;
                TBCorreo.Text = editable.correoElectronico;
                TBDireccion.Text = editable.direccion;
                TBEmpresa.Text = editable.empresa;
                TBTelefono.Text = editable.numeroTelefono;
            } 
        }

        private void GuardarPatrocinador(object sender,RoutedEventArgs e) {
            using (var container = new DataModelContainer()) {
                var result = container.PatrocinadorSet.SingleOrDefault(patrocinador => patrocinador.Id == editable.Id);
                if (result != null) {
                    result = editable;
                    container.SaveChanges();
                }
            }
        }

        private void CancelarModificacion(object sender,RoutedEventArgs e) {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
