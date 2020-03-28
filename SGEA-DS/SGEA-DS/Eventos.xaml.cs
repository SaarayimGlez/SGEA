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

namespace SGEA_DS {
    /// <summary>
    /// Lógica de interacción para Eventos.xaml
    /// </summary>
    public partial class Eventos: Window {
        private int centinel;

        public int Centinel { get => centinel; set => centinel = value; }

        public Eventos(int centinel) {
            Centinel = centinel;
            InitializeComponent();
            CargarDatos();
        }

        private void MostrarActividaes(object sender,MouseButtonEventArgs e) {
            if (LBEventos.SelectedItem != null) {
                switch (Centinel) {
                    case 13:
                        Actividades actividades = new Actividades();
                        actividades.Evento = (Evento)LBEventos.SelectedItem;
                        actividades.Centinel = Centinel;
                        actividades.Show();
                        this.Close();
                        break;
                    case 37:
                        Magistrales magistrales = new Magistrales((Evento)LBEventos.SelectedItem);
                        magistrales.Show();
                        this.Close();
                        break;
                }
            }
        }

        private void CargarDatos() {
            using (var container = new DataModelContainer()) {
                var eventos = (from evento in container.EventoSet
                                      orderby evento.Id
                                      select evento).ToList();
                LBEventos.ItemsSource = eventos;
            }
        }
    }
}
