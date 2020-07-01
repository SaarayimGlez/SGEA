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
    /// Lógica de interacción para ModificarEvaluacion.xaml
    /// </summary>
    public partial class ModificarEvaluacion : Window
    {
        private List<Evaluacion> listaEvaluaciones;
        private List<object> articulo;
        public ModificarEvaluacion(List<object> articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            LlenarCombobox();

        }

        private void LlenarCombobox()
        {
            Evaluacion_Logica evaluacionLogica = new Evaluacion_Logica();
            if (!evaluacionLogica.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listaEvaluaciones = evaluacionLogica.RecuperarEvaluaciones();
                foreach( Evaluacion evaluacion in listaEvaluaciones)
                {
                    combobox_Evaluacion.Items.Add(evaluacion.descripcion);
                }
            }
        }

        private void Button_Siguiente_Click(object sender, RoutedEventArgs e)
        {
            if (combobox_Evaluacion.Text == "")
            {
                label_Mensaje.Content = "Seleccione una evaluación";
            }
            else
            {
                int idEvaluacion = listaEvaluaciones[combobox_Evaluacion.SelectedIndex].Id;
                String descripicion = listaEvaluaciones[combobox_Evaluacion.SelectedIndex].descripcion;
                int calificacion = listaEvaluaciones[combobox_Evaluacion.SelectedIndex].calificacion;
                System.DateTime fecha = listaEvaluaciones[combobox_Evaluacion.SelectedIndex].fecha;
                ModificarEvaluacion_2 modificarEvaluacion = new ModificarEvaluacion_2(this.articulo, idEvaluacion, descripicion, calificacion, fecha);
                modificarEvaluacion.Show();
                this.Close();
            }
        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            MenuEvaluador menuEvaluador = new MenuEvaluador(this.articulo);
            menuEvaluador.Show();
            this.Close();
        }
    }
}
