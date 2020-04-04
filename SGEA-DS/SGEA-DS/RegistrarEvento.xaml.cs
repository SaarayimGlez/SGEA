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
using DataAccess;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para RegistrarEvento.xaml
    /// </summary>
    public partial class RegistrarEvento : Window
    {
        public RegistrarEvento()
        {
            InitializeComponent();
        }

        private void GuardarEvento(object sender, RoutedEventArgs e)
        {
            Evento nuevo = new Evento();
            if (ValidarDatos()) { 
                nuevo.nombre = TBnombre.Text;
                nuevo.fechaInicio = (DateTime)DPinicio.SelectedDate;
                nuevo.fechaFin = (DateTime)DPfin.SelectedDate;
                nuevo.institucionOrganizadora = CBinstitucion.Text;
                nuevo.lugar = TBlugar.Text;
            } else
            {
                LBMensage.Content = "Los datos son incorrectos, por favor verifique su información*";
                return;
            }
            try {
                DataModelContainer container = new DataModelContainer();
                container.EventoSet.Add(nuevo);
                container.SaveChanges();
                LBMensage.Content = "Evento creado con éxito*";
            }
            catch (Exception ex)
            {
                LBMensage.Content = "No hay conexión a la base de datos, inténtelo más tarde";
                MessageBox.Show(ex.Message,e.GetType().ToString());
            }
        }

        private void CancelarEvento(object sender, RoutedEventArgs e)
        {
            VentanaPrincipal main = new VentanaPrincipal();
            main.Show();
            this.Close();
        }

        private bool ValidarDatos()
        {
            bool centinel = true;
            if (!string.IsNullOrEmpty(TBnombre.Text))
            {
                foreach(char caracter in TBnombre.Text)
                {
                    if (!char.IsLetter(caracter))
                    {
                        centinel = false;
                    }
                }
            }
            else
            {
                centinel = false;
            }
            if (string.IsNullOrEmpty(DPinicio.SelectedDate.ToString()))
            {
                centinel = false;
            }
            if (string.IsNullOrEmpty(DPfin.SelectedDate.ToString()))
            {
                centinel = false;
            }
            if (CBinstitucion.SelectedIndex < 0)
            {
                centinel = false;
            }
            if (!string.IsNullOrEmpty(TBlugar.Text))
            {
                foreach (char caracter in TBlugar.Text)
                {
                    if (!char.IsLetter(caracter))
                    {
                        centinel = false;

                    }
                }
            }
            else
            {
                centinel = false;
            }
            return centinel;
        }
    }
}
