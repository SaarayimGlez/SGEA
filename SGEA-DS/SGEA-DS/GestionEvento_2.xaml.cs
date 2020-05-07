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
    /// Lógica de interacción para GestionEvento_2.xaml
    /// </summary>
    public partial class GestionEvento_2 : Window
    {
        private Modelo.Evento evento;

        public GestionEvento_2()
        {
            InitializeComponent();
        }

        public GestionEvento_2(Modelo.Evento evento)
        {
            InitializeComponent();
            this.evento = evento;
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            GestionEvento gestionEvento = new GestionEvento();
            gestionEvento.Show();
            this.Close();
        }

        private void Click_Actividades(object sender, RoutedEventArgs e)
        {
            GestionActividades gestionActividades = new GestionActividades();
            gestionActividades.Show();
            this.Close();
        }

        private void Click_GenerarPrograma(object sender, RoutedEventArgs e)
        {
            CU05 generarPrograma = new CU05(this.evento);
            generarPrograma.Show();
            this.Close();
        }

        private void Click_Egresos(object sender, RoutedEventArgs e)
        {
            GestionEgreso gestionEgreso = new GestionEgreso();
            gestionEgreso.Show();
            this.Close();
        }

        private void Click_Comites(object sender, RoutedEventArgs e)
        {
            GestionComite gestionComite = new GestionComite(this.evento);
            gestionComite.Show();
            this.Close();
        }

        private void Click_ModificarEvento(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Click_ConsultaDatosP(object sender, RoutedEventArgs e)
        {
            ConsultaDatosPersonales consultaDatosPersonales = new ConsultaDatosPersonales();
            consultaDatosPersonales.Show();
            this.Close();
        }

        private void Click_RegistroPresupuesto(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
