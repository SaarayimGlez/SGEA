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
using Logica;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para EnviarEvaluacion.xaml
    /// </summary>
    public partial class EnviarEvaluacion : Window
    {
        
        private List<object> articulo;
        private List<Evaluacion> listaEvaluaciones;

        public EnviarEvaluacion(List<object> articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            LlenarCombobox();
        }

        private void LlenarCombobox()
        {
            Evaluacion_Logica evaluacion_Logica = new Evaluacion_Logica();
            if (!evaluacion_Logica.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listaEvaluaciones = evaluacion_Logica.RecuperarEvaluaciones();
                foreach(Evaluacion evaluacionN in listaEvaluaciones)
                {
                    comboBox_Evaluaciones.Items.Add(evaluacionN.descripcion);
                }
            }
        }

        private void Button_Siguiente_Click(object sender, RoutedEventArgs e)
        {
            if(comboBox_Evaluaciones.Text == "")
            {
                label_Mensaje.Content = "Seleccione una evaluación";
            }
            else
            {
                String descripcion = listaEvaluaciones[comboBox_Evaluaciones.SelectedIndex].descripcion;
                int calificacion = listaEvaluaciones[comboBox_Evaluaciones.SelectedIndex].calificacion;
                String Scalificacion = "Descripcion: "+descripcion + " Calificacion: "+calificacion.ToString();
                EnviarEvaluacion_2 evaluacion2 = new EnviarEvaluacion_2(Scalificacion, this.articulo);
                evaluacion2.Show();
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
