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
using Logica;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para ConsultarComite.xaml
    /// </summary>
    public partial class ConsultarComite : Window
    {
        private Modelo.Evento evento;
        private List<Comite> listaComites;

        public ConsultarComite()
        {
            InitializeComponent();
        }

        public ConsultarComite(Modelo.Evento evento)
        {
            InitializeComponent();
            this.evento = evento;
            LlenarCombobox();
        }

        private void LlenarCombobox()
        {
            Comite_Logica comite = new Comite_Logica();
            if (!comite.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listaComites = comite.GenerarListaComite();
                foreach(Comite comiteN in listaComites)
                {
                    combobox_Comite.Items.Add(comiteN.nombre);
                }

            }
        }

        private void Button_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if (combobox_Comite.Text == "")
            {
                label_Mensaje.Content = "Seleccione un comité";
            }
            else
            {
                int idComite = listaComites[combobox_Comite.SelectedIndex].Id;
                ConsultarComite_2 consultarComite_2 = new ConsultarComite_2(idComite, this.evento);
                consultarComite_2.Show();
                this.Close();
            }
        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            GestionComite gestionComite = new GestionComite(this.evento);
            gestionComite.Show();
            this.Close();
        }
    }
}
