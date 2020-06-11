using Logica;
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
    /// Lógica de interacción para GestionArticulo.xaml
    /// </summary>
    public partial class GestionArticulo : Window
    {
        private List<List<object>> listaArticulo;
        private MiembroComite miembroComite;

        public GestionArticulo(MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            LlenarComboBox();
        }

        public GestionArticulo(int miembroComiteId)
        {
            InitializeComponent();
            this.miembroComite = new MiembroComite() { Id = miembroComiteId };
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            Articulo_Logica articulo_Logica = new Articulo_Logica();
            if (!articulo_Logica.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(
                    new Run("Se ha perdido conexión con la base de datos")
                    {
                        Foreground = Brushes.Red
                    });
                textBlock_mensaje.Inlines.Add(bold);
            }
            else
            {
                this.listaArticulo = articulo_Logica.RecuperarArticuloEvaluador(this.miembroComite.Id);
                foreach (var articulo in listaArticulo)
                {
                    comboBox_articulo.Items.Add(articulo[1]);
                }
            }
        }

        private void Combobox_Articulo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            button_continuar.IsEnabled = true;
        }

        private void Click_Continuar(object sender, RoutedEventArgs e)
        {
            foreach (var articulo in listaArticulo)
            {
                if (comboBox_articulo.SelectedItem.ToString().Equals(articulo[1]))
                {
                    MenuEvaluador menuEvaluador = new MenuEvaluador(articulo);
                    menuEvaluador.Show();
                    this.Close();
                }
            }
        }

        private void Click_CerrarSesion(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Click_ModificarContrasena(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
