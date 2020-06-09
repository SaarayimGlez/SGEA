using System.Windows;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para DetallesAsistente.xaml
    /// </summary>
    public partial class DetallesAsistente: Window {
        //private Asistente asistenteMostrado;
        //private Asistentes asistentesVentana;

        public DetallesAsistente() {
            InitializeComponent();
        }

        /*public Asistente AsistenteMostrado { get { return asistenteMostrado; }
            set { asistenteMostrado = value;
                TBNombre.Text = asistenteMostrado.nombre;
                TBPaterno.Text = asistenteMostrado.apellidoPaterno;
                TBMaterno.Text = asistenteMostrado.apellidoMaterno;
                TBCorreo.Text = asistenteMostrado.correoElectronico;
            }
        }
        public Asistentes AsistentesVentana { get => asistentesVentana; set => asistentesVentana = value; }

        private void RegresarVentana(object sender,RoutedEventArgs e) {
            asistentesVentana.Show();
            this.Close();
        }*/
    }
}
