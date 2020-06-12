using Modelo;
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

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para MenuEvaluador.xaml
    /// </summary>
    public partial class MenuEvaluador : Window
    {
        private List<object> articulo;

        public MenuEvaluador(List<object> articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        public MenuEvaluador(List<object> articulo, bool articuloAceptado)
        {
            InitializeComponent();
            this.articulo = articulo;
            textBlock_mensaje.Text = String.Empty;
            var bold = new Bold(new Run("No se puede registrar una evaluación, " +
                "el artículo ya fue aceptado")
            {
                Foreground = Brushes.Red
            });
            textBlock_mensaje.Inlines.Add(bold);
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            GestionArticulo gestionArticulo = new GestionArticulo((int)this.articulo[6]);
            gestionArticulo.Show();
            this.Close();
        }

        private void Click_RegistrarEvaluacion(object sender, RoutedEventArgs e)
        {
            CU33 registrarEvaluacion = new CU33(this.articulo);
            registrarEvaluacion.Show();
            this.Close();
        }

        private void Click_ModificarEvaluacion(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Click_EnviarEvaluacion(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
