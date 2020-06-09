using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para Patrocinadores.xaml
    /// </summary>
    public partial class Patrocinadores : Window
    {
        /*public Patrocinadores()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos() {
            try {
                using (var container = new DataModelContainer()) {
                    var patrocinadores = (from patrocinador in container.PatrocinadorSet
                                          orderby patrocinador.Id
                                          select patrocinador).ToList();
                    LBpatrocinadores.ItemsSource = patrocinadores;
                }
            } catch (Exception) {
                LBMensaje.Content = "No hay conexión a la base de datos, inténtelo más tarde";
            }
        }

        private void MandarAModificar(object sender,MouseButtonEventArgs e) {
            if (LBpatrocinadores.SelectedItem != null) {
                ModificarPatrocinador modificar = new ModificarPatrocinador();
                modificar.Editable = (Patrocinador)LBpatrocinadores.SelectedItem;
                modificar.Show();
                this.Close();
            }
        }*/
    }
}
