
using System.Windows;
using Logica;
using Modelo;
using System.Collections.Generic;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para ConsultarComite_2.xaml
    /// </summary>
    public partial class ConsultarComite_2 : Window
    {
        private Modelo.Comite comite;
        private Modelo.Evento evento;
        private int idComite;
        private List<MiembroComite> listaMiembroC;

        public ConsultarComite_2(int idComite, Modelo.Evento evento)
        {
            InitializeComponent();
            this.evento = evento;
            this.idComite = idComite;
            LlenarCombobx();
            LlenarDatos();
        }

       private void LlenarDatos()
        {
            Comite_Logica comite_Logica = new Comite_Logica();
            if (!comite_Logica.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                label_Nombre.Content = comite_Logica.RecuperarComite(idComite).nombre;
                label_Descripcion.Content = comite_Logica.RecuperarComite(idComite).descripcion;

            }
        }

        private void LlenarCombobx()
        {
            MiembroComite_Logica miembroComite_Logica = new MiembroComite_Logica();
            if (!miembroComite_Logica.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listaMiembroC = miembroComite_Logica.RecuperarMiembroComitePorComite(idComite);
                foreach (MiembroComite miembroComite in listaMiembroC)
                {
                    combobox_MiembrosC.Items.Add(miembroComite.nombre + " " + miembroComite.apellidoPaterno +
                        " " + miembroComite.apellidoMaterno);
                }
            }
        }

        private void Button_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            ConsultarComite consultarComite = new ConsultarComite(this.evento);
            consultarComite.Show();
            this.Close();
        }
    }
}
