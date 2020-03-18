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
using SGEA_DS.Datos;

namespace SGEA_DS.Eventos
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
            try
            {
                nuevo.nombre = TBnombre.Text;
                nuevo.fechaInicio = (DateTime)DPinicio.SelectedDate;
                nuevo.fechaFin = (DateTime)DPfin.SelectedDate;
                nuevo.institucionOrganizadora = CBinstitucion.Text;
                nuevo.lugar = TBlugar.Text;
            }catch(Exception)
            {
                LBMensage.Content = "Los datos son incorrectos, por favor verifique su información*";
            }
            try
            {
                DataContainer1 container1 = new DataContainer1();
                container1.EventoSet.Add(nuevo);
                container1.SaveChanges();
                LBMensage.Content = "Evento creado con éxito*";
            }
            catch(Exception ex)
            {
                LBMensage.Content = "No hay conexión a la base de datos, inténtelo más tarde";
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
        }

        private void CancelarEvento(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
