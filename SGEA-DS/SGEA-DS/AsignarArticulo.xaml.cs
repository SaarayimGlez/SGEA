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
    /// Lógica de interacción para AsignarArticulo.xaml
    /// </summary>
    public partial class AsignarArticulo : Window
    {
        Modelo.MiembroComite miembroComite;
        private List<Articulo> listaArticulos;

        public AsignarArticulo(Modelo.MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            LlenarCombobox();
        }

        private void LlenarCombobox()
        {
            Articulo_Logica articuloLogica = new Articulo_Logica();
            if (!articuloLogica.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listaArticulos = articuloLogica.RecuperarArticulo();
                foreach (Articulo articuloN in listaArticulos)
                {
                    combobox_Articulos.Items.Add(articuloN.titulo);
                }
            }
        }

        private void Button_Continuar_Click(object sender, RoutedEventArgs e)
        {
            if (combobox_Articulos.Text == "")
            {
                label_Mensaje.Content = "Seleccione un articulo";
            }
            else
            {
                Articulo_Logica articulo_Logica = new Articulo_Logica();
                if (!articulo_Logica.ComprobarConexion())
                {
                    label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
                }
                else
                {
                    int idArticulo = listaArticulos[combobox_Articulos.SelectedIndex].Id;
                    AsignarArticulo_2 asignarArticulo = new AsignarArticulo_2(this.miembroComite, idArticulo);
                    asignarArticulo.Show();
                    this.Close();
                }
            }
        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            GestionAutorArticulo gestionAutorArticulo = new GestionAutorArticulo(this.miembroComite);
            gestionAutorArticulo.Show();
            this.Close();
        }
    }
}
