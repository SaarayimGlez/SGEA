using Logica;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para CU23_1.xaml
    /// </summary>
    public partial class CU23_1 : CtrolUsrCtrolEvento
    {
        private Modelo.MiembroComite miembroComite;
        private List<Modelo.MiembroComite> listaModeloComite;

        public CU23_1(Modelo.MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            MiembroComite_Logica miembroComite_Logica = new MiembroComite_Logica();
            Evento_Logica evento_Logica = new Evento_Logica();
            if (!miembroComite_Logica.ComprobarConexion())
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
                List<Modelo.Evento> eventoMiembroComite = 
                    evento_Logica.RecuperarEventos(this.miembroComite.ComiteId);
                this.listaModeloComite = 
                    miembroComite_Logica.RecuperarMiembroComitePorEvento(eventoMiembroComite[0].Id);
                foreach (Modelo.MiembroComite miembroComite in listaModeloComite)
                {
                    comboBox_miembroComite.Items.Add(miembroComite.nombre + " " +
                        miembroComite.apellidoPaterno + " " + miembroComite.apellidoMaterno);
                }
            }
        }

        private void Combobox_MiembroComite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            button_aceptar.IsEnabled = true;
        }

        private void Click_Aceptar(object sender, RoutedEventArgs e)
        {
            foreach (Modelo.MiembroComite miembroComite in listaModeloComite)
            {
                if (comboBox_miembroComite.SelectedItem.ToString().Equals(
                    miembroComite.nombre + " " + miembroComite.apellidoPaterno + " " + 
                    miembroComite.apellidoMaterno))
                {
                    Switcher.Switch(new CU23_2(miembroComite, this.miembroComite));
                }
            }
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            GestionMiembroComite gestionMiembroComite =
                new GestionMiembroComite(this.miembroComite, 1);
            gestionMiembroComite.Show();
            var window = Window.GetWindow(this);
            window.Close();
        }
    }
}
