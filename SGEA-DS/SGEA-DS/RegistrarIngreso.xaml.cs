using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace SGEA_DS {
    /// <summary>
    /// Lógica de interacción para RegistrarIngreso.xaml
    /// </summary>
    public partial class RegistrarIngreso : Window {

        private Evento evento;

        public RegistrarIngreso(Evento evento)
        {
            InitializeComponent();
            this.evento = evento;
            OcultarCampos();
        }
        //oculta los campos de "otro" y "articulo"
        public void OcultarCampos()
        {
            textBox_Otro.IsEnabled = false;
            label_Otro.IsEnabled=false;
            comboBox_Articulo.IsEnabled = false;
        }
        //Desplega el combobox del artículo
        private void DesplegarArticulo(object sender, RoutedEventArgs e)
        {
            OcultarCampos();
            comboBox_Articulo.IsEnabled = true;
        }
        //desplega el text box para especificar un concepto
        private void DesplegarOtro(object sender, RoutedEventArgs e)
        {
            OcultarCampos();
            textBox_Otro.IsEnabled = true;
            label_Otro.IsEnabled = true;
        }

        private void Guadar(object sender, RoutedEventArgs e)
        {
            if (textBox_CantidadIngreso.Text=="")
            {
                label_Mensaje.Content = "Favor de especificar una cantidad de ingreso";
            }
            else
            {
                Ingreso_Logica ingreso = new Ingreso_Logica();
                if (!ingreso.ComprobarConexion())
                {
                    label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
                }
                else
                {
                    if(textBox_Otro.Text != "")
                    {
                        DateTime thisDay = DateTime.Today; //gurada la fecha en la que se está haciendo el registro
                        Ingreso nuevoIngreso = new Ingreso()
                        {
                            concepto = textBox_Otro.Text,
                            fecha = thisDay,
                            monto = float.Parse(textBox_CantidadIngreso.Text, NumberFormatInfo.InvariantInfo)
                        };
                        ingreso.RegistrarIngreso(nuevoIngreso);
                        label_Mensaje.Content = "Se ha registrado el ingreso con éxito";
                    }
                }
            }
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            GestionEvento_2 gestionEvento = new GestionEvento_2(this.evento);
            gestionEvento.Show();
            this.Close();
        }
        private void ComboBox_Articulo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
