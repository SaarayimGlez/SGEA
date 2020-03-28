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
    /// Lógica de interacción para DetallesActividad.xaml
    /// </summary>
    public partial class DetallesActividad: Window {
        private Actividad actividad;
        private Actividades ventana;

        public DetallesActividad(Actividad actividad, Actividades actividades) {
            Actividad = actividad;
            Ventana = actividades;
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos() {
            TBNombre.Text = Actividad.nombre;
            TBCosto.Text = Actividad.costo.ToString();
            TBTipo.Text = Actividad.tipo;
            TBAula.Text = Actividad.aula;
        }

        public Actividad Actividad { get => actividad; set => actividad = value; }
        public Actividades Ventana { get => ventana; set => ventana = value; }

        private void RegresarVentana(object sender,RoutedEventArgs e) {
            Ventana.Show();
            this.Close();
        }
    }
}
