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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para CU26_1.xaml
    /// </summary>
    public partial class CU26_1 : CtrolUsrCtrolEvento
    {
        private List<List<string>> listaActividad;
        private MiembroComite miembroComite;

        public CU26_1(MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            Actividad_Logica actividad_Logica = new Actividad_Logica();
            Evento_Logica evento_Logica = new Evento_Logica();
            if (!actividad_Logica.ComprobarConexion())
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
                List<Evento> eventoMiembroComite =
                    evento_Logica.RecuperarEventos(this.miembroComite.ComiteId);
                this.listaActividad = 
                    actividad_Logica.RecuperarProgramaEvento(eventoMiembroComite[0].Id);
                foreach (List<string> actividad in listaActividad)
                {
                    comboBox_actividad.Items.Add(actividad[0]);
                }
            }
        }

        private void Combobox_Magistral_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            button_aceptar.IsEnabled = true;
        }

        private void Click_Aceptar(object sender, RoutedEventArgs e)
        {
            foreach (List<string> actividad in listaActividad)
            {
                if (comboBox_actividad.SelectedItem.ToString().Equals(actividad[0]))
                {
                    Switcher.Switch(new CU26_2(Convert.ToInt32(actividad[8]), this.miembroComite));
                }
            }
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            GestionMiembroComite gestionMiembroComite =
                new GestionMiembroComite(this.miembroComite, 2);
            gestionMiembroComite.Show();
            var window = Window.GetWindow(this);
            window.Close();
        }
    }
}
