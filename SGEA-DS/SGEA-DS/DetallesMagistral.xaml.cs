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
    /// Lógica de interacción para DetallesMagistral.xaml
    /// </summary>
    public partial class DetallesMagistral: Window {
        private Magistral magistral;
        private Magistrales magistrales;

        public DetallesMagistral(Magistral magistral, Magistrales magistrales) {
            Magistral = magistral;
            Magistrales = magistrales;
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos() {
            TBNombre.Text = Magistral.nombre + Magistral.apellidoPaterno + Magistral.apellidoMaterno;
            TBAdscripción.Text = Magistral.Adscripcion.nombre;
            TBDireccion.Text = Magistral.Adscripcion.direccion;
            TBEmail.Text = Magistral.Adscripcion.correoElectronico;
            TBEstado.Text = Magistral.Adscripcion.estado;
        }

        public Magistral Magistral { get => magistral; set => magistral = value; }
        public Magistrales Magistrales { get => magistrales; set => magistrales = value; }

        private void RegresarVentana(object sender,RoutedEventArgs e) {
            Magistrales.Show();
            this.Close();
        }
    }
}
