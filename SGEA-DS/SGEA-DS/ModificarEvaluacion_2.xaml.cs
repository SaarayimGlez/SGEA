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
    /// Lógica de interacción para ModificarEvaluacion_2.xaml
    /// </summary>
    public partial class ModificarEvaluacion_2 : Window
    {
        private List<object> articulo;
        private int id;

        public ModificarEvaluacion_2(List<object> articulo, int idEvaluacion, String descripcion, int calificacion, System.DateTime fecha)
        {
            InitializeComponent();
            this.articulo = articulo;
            textBox_Calificacion.Text = calificacion.ToString();
            textBox_fecha.Text = fecha.ToString();
            textBlock_Descripcion.Text = descripcion;
            this.id = idEvaluacion;
        }

        private bool ComprobarCampos()
        {
            if(textBlock_Descripcion.Text==""|| textBox_Calificacion.Text == "" || textBox_fecha.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Button_Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (ComprobarCampos() == false)
            {
                label_Mensaje.Content = "Favor de completar todos los campos";
            }
            else
            {
                Evaluacion_Logica evaluacion_Logica = new Evaluacion_Logica();
                if (!evaluacion_Logica.ComprobarConexion())
                {
                    label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
                }
                else
                {
                    try
                    {
                        int calificacion = int.Parse(textBox_Calificacion.Text);
                        System.DateTime fecha = DateTime.Parse(textBox_fecha.Text);
                        evaluacion_Logica.ModificarEvalucion(this.id, textBlock_Descripcion.Text,
                            calificacion, fecha);
                        label_Mensaje.Content = "Se ha modificado la evaluación con éxito";
                    }
                    catch(FormatException exception)
                    {
                        label_Mensaje.Content = "Datos incorrectos"+ " "+ exception;
                    }
                }
            }
        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            ModificarEvaluacion modificarEvaluacion = new ModificarEvaluacion(this.articulo);
            modificarEvaluacion.Show();
            this.Close();
        }
    }
}
