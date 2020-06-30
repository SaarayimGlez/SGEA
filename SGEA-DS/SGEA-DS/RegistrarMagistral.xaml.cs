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
    /// Lógica de interacción para RegistrarMagistral.xaml
    /// </summary>
    public partial class RegistrarMagistral : Window
    {
        private Modelo.MiembroComite miembroComite;
        private List<Adscripcion> listaAdscripcion;

        public RegistrarMagistral(Modelo.MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            LlenarCombobox(); 
        }

        private void LlenarCombobox()
        {
            Adscripcion_Logica adscripcion = new Adscripcion_Logica();
            if (!adscripcion.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listaAdscripcion = adscripcion.RecuperarListaAdscripcion();
                foreach (Adscripcion adscripcionN in listaAdscripcion)
                {
                    comboBox_Adscripcion.Items.Add(adscripcionN.nombre);
                }
            }
        }

        private bool ComprobarDatos()
        {
            if(textBox_Nombre.Text=="" || textBox_ApellidoP.Text == "" || textBox_ApellidoM.Text=="")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Button_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if (ComprobarDatos() == false)
            {
                label_Mensaje.Content = "Favor de completar todos los campos";
            }
            else
            {
                Magistral_Logica magistral_Logica = new Magistral_Logica();
                Modelo.Magistral magistral = new Modelo.Magistral();
                magistral.nombre = textBox_Nombre.Text;
                magistral.apellidoPaterno = textBox_ApellidoP.Text;
                magistral.apellidoMaterno = textBox_ApellidoM.Text;
                magistral.AdscripcionId = listaAdscripcion[comboBox_Adscripcion.SelectedIndex].Id;
                magistral_Logica.RegistrarMagistral(magistral);
                label_Mensaje.Content = "Se ha registrado al magistral con éxito";
            }
        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            GestionMiembroComite gestionMiembroComite = new GestionMiembroComite(this.miembroComite, 3);
            gestionMiembroComite.Show();
            this.Close();

        }
    }
}
