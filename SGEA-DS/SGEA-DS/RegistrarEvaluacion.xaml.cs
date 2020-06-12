using Logica;
using Microsoft.WindowsAPICodePack.Shell;
using Modelo;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para CU33.xaml
    /// </summary>
    public partial class CU33 : Window
    {
        private List<object> articulo;
        private string rutaArticulo;

        public CU33(List<object> articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Loaded += delegate
            {
                if ((bool)articulo[5])
                {
                    Click_Cancelar(new object(), new RoutedEventArgs());
                } else
                {
                    LlenarCamposArticulo();
                } 
            };  
        }

        private void LlenarCamposArticulo()
        {
            textBox_titulo.Text = (string)articulo[1];
            textBox_keyword.Text = (string)articulo[2];
            textBox_abstract.Text = (string)articulo[3];
            this.rutaArticulo = (string)articulo[4];
            textBox_autor.Text = (string)articulo[7];
        }

        private void Click_DescargarDocumento(object sender, RoutedEventArgs e)
        {
            string sourceLocation = rutaArticulo;
            string directorioDestino = KnownFolders.Downloads.Path + @"\Articulos";
            string dstnLocation = string.Format(directorioDestino + @"\{0}",
                System.IO.Path.GetFileName(sourceLocation));

            if (!System.IO.Directory.Exists(directorioDestino))
            {
                System.IO.Directory.CreateDirectory(directorioDestino);
            }

            System.IO.File.Copy(sourceLocation, dstnLocation, true);
        }

        private void Click_Aceptar(object sender, RoutedEventArgs e)
        {
            if (ValidarDatos() && NuevaEvaluacion())
            {
                if (!textBlock_mensaje.Text.Equals("Se ha perdido conexión con la base de datos"))
                {
                    textBlock_mensaje.Text = String.Empty;
                    var bold = new Bold(new Run("Comité registrado con éxito"));
                    textBlock_mensaje.Inlines.Add(bold);
                }
                textBox_descripcion.IsEnabled = false;
                BasicRatingBar.IsEnabled = false;
                checkBox_articuloAceptado.IsEnabled = false;
            }
            else
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run(
                    "Hay datos incompletos, favor de revisar"
                    )
                { Foreground = Brushes.Red });
                textBlock_mensaje.Inlines.Add(bold);
            }
        }

        private bool NuevaEvaluacion()
        {
            Evaluacion_Logica evaluacion_Logica = new Evaluacion_Logica();
            if (!evaluacion_Logica.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Se ha perdido conexión con la base de datos")
                {
                    Foreground = Brushes.Red
                });
                textBlock_mensaje.Inlines.Add(bold);
                return true;
            }
            Evaluacion nuevaEvaluacion = new Evaluacion();
            string[] calificacion = textBlock_calificacion.Text.Split(':');
            nuevaEvaluacion.calificacion = Convert.ToInt32(calificacion[1].Trim());
            nuevaEvaluacion.descripcion = textBox_descripcion.Text;
            nuevaEvaluacion.fecha = DateTime.Now;
            nuevaEvaluacion.ArticuloId = (int)this.articulo[0];
            nuevaEvaluacion.MiembroComite_Id = (int)this.articulo[6];
            if (evaluacion_Logica.RegistrarEvaluacion(nuevaEvaluacion) && 
                checkBox_articuloAceptado.IsChecked == true)
            {
                Articulo_Logica articulo_Logica = new Articulo_Logica();
                this.articulo[5] = true;
                return articulo_Logica.ModificarStatusArticulo((int)this.articulo[0]);
            }
            return true;
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(textBox_descripcion.Text))
            {
                return false;
            }
            if (textBlock_calificacion.Text == "Calificación: 0")
            {
                return false;
            }
            return true;
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_titulo.Text))
            {
                MenuEvaluador menuEvaluador = new MenuEvaluador(this.articulo, false);
                menuEvaluador.Show();
                this.Close();
            } else
            {
                MenuEvaluador menuEvaluador = new MenuEvaluador(this.articulo);
                menuEvaluador.Show();
                this.Close();
            }
        }
    }
}
