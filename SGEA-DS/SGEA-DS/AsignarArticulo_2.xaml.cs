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
    /// Lógica de interacción para AsignarArticulo_2.xaml
    /// </summary>
    public partial class AsignarArticulo_2 : Window
    {

        Modelo.MiembroComite miembroComite;
        private List<MiembroComite> listaMiembros;
        private int idArticulo;

        public AsignarArticulo_2(Modelo.MiembroComite miembroComite, int idArticulo)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            this.idArticulo = idArticulo;
            LlenarCombobox();
        }

        private void LlenarCombobox()
        {
            MiembroComite_Logica miembroComiteC = new MiembroComite_Logica();
            if (!miembroComiteC.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listaMiembros = miembroComiteC.RecuperarMiembroComiteEvaluador();
                foreach(MiembroComite miembroComite in listaMiembros)
                {
                    combobox_Evaluador.Items.Add(miembroComite.nombre + " " + miembroComite.apellidoPaterno + " " +
                        miembroComite.apellidoPaterno);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (combobox_Evaluador.Text == "")
            {
                label_Mensaje.Content = "Seleccione un evaluador";
            }
            else
            {
                Evaluacion_Logica evaluacion_Logica = new Evaluacion_Logica();
                if (!evaluacion_Logica.ComprobarConexion())
                {
                    label_Mensaje.Content = "Se ha perdido la coenxión con la base de datos";
                }
                else
                {
                    int idEvaluador = listaMiembros[combobox_Evaluador.SelectedIndex].Id;
                    evaluacion_Logica.RegistrarIdEvauacion(idEvaluador, idArticulo);
                    label_Mensaje.Content = "Se ha asignado el artículo con éxito";
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AsignarArticulo asignarArticulo = new AsignarArticulo(this.miembroComite);
            asignarArticulo.Show();
            this.Close();
        }
    }
}
