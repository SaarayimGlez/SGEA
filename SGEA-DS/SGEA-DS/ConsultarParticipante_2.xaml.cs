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
using Modelo;
using Logica;
namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para ConsultarParticipante_2.xaml
    /// </summary>
    public partial class ConsultarParticipante_2 : Window
    {
        int idAd;
        private Evento evento;

        public ConsultarParticipante_2(String nombre, String paterno, String materno, String titulo, int idA, Evento evento)
        {
            InitializeComponent();
            label_Nombre.Content = nombre;
            label_ApellidoP.Content = paterno;
            label_ApellidoM.Content = materno;
            label_Titulo.Content = titulo;
            this.idAd = idA;
            LlenarCamposAdscripcion();
            this.evento = evento;
        }

        private void LlenarCamposAdscripcion()
        {
            Adscripcion_Logica adscripcion = new Adscripcion_Logica();
            adscripcion.RecuperarAdscripcion(idAd);
            label_NombreAds.Content = adscripcion.RecuperarAdscripcion(idAd).nombre;
            label_Ciudad.Content = adscripcion.RecuperarAdscripcion(idAd).ciudad;
            label_Direccion.Content = adscripcion.RecuperarAdscripcion(idAd).direccion;
            label_Estado.Content = adscripcion.RecuperarAdscripcion(idAd).estado;
            label_Email.Content = adscripcion.RecuperarAdscripcion(idAd).correoElectronico;
        }

        private void Button_Click_Cancelar(object sender, RoutedEventArgs e)
        {
            ConsultarParticipante participante = new ConsultarParticipante(this.evento);
            participante.Show();
            this.Close();
        }
    }
}
