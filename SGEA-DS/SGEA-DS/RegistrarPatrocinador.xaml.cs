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
using System.Text.RegularExpressions;
using Modelo;

namespace SGEA_DS
{
    public partial class CU06 : VentanaCtrolEvento
    {

        public CU06()
        {
            InitializeComponent();
        }

        public CU06(int eventoId)
        {
            InitializeComponent();
        }
        
        private void Click_Aceptar(object sender, RoutedEventArgs e)
        {
            if (ValidarDatos() && NuevoPatrocinador())
            {
                if (!textBlock_mensaje.Text.Equals("Se ha perdido conexión con la base de datos"))
                {
                    textBlock_mensaje.Text = String.Empty;
                    var bold = new Bold(new Run("Patrocinador registrado con éxito"));
                    textBlock_mensaje.Inlines.Add(bold);
                }
                textBox_nombre.Text = "";
                textBox_apellidoP.Text = "";
                textBox_apellidoM.Text = "";
                textBox_empresa.Text = "";
                textBox_direccion.Text = "";
                textBox_correoE.Text = "";
                textBox_numeroTel.Text = "";
            }
            else
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run(
                    "Hay datos inválidos o el patrocinador ya existe, favor de revisar")
                    {
                        Foreground = Brushes.Red
                    });
                textBlock_mensaje.Inlines.Add(bold);
            }
        }

        private bool NuevoPatrocinador()
        {
            Patrocinador_Logica patrocinadorDAO = new Patrocinador_Logica();
            if (!patrocinadorDAO.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Se ha perdido conexión con la base de datos")
                {
                    Foreground = Brushes.Red
                });
                textBlock_mensaje.Inlines.Add(bold);
                return true;
            }
            return patrocinadorDAO.RegistrarPatrocinador(new Modelo.Patrocinador() {
                nombre = textBox_nombre.Text,
                apellidoPaterno = textBox_apellidoP.Text,
                apellidoMaterno = textBox_apellidoM.Text,
                empresa = textBox_empresa.Text,
                direccion = textBox_direccion.Text,
                correoElectronico = textBox_correoE.Text,
                numeroTelefono = textBox_numeroTel.Text
            } );
        }

        private bool ValidarDatos()
        {
            if (textBox_nombre.Text.Any(char.IsPunctuation) | 
                textBox_apellidoP.Text.Any(char.IsPunctuation) | 
                textBox_apellidoM.Text.Any(char.IsPunctuation) | 
                textBox_nombre.Text.Any(char.IsDigit) | 
                textBox_apellidoP.Text.Any(char.IsDigit) | 
                textBox_apellidoM.Text.Any(char.IsDigit) |
                string.IsNullOrWhiteSpace(textBox_nombre.Text) |
                string.IsNullOrWhiteSpace(textBox_apellidoP.Text) |
                string.IsNullOrWhiteSpace(textBox_direccion.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox_correoE.Text) |
                string.IsNullOrWhiteSpace(textBox_numeroTel.Text) | 
                textBox_numeroTel.Text.Any(char.IsLetter) | 
                textBox_numeroTel.Text.Any(char.IsPunctuation))
            { 
                return false;
            }
            if (!Regex.IsMatch(
                textBox_correoE.Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                return false;
            }
            return true;
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            GestionPatrocinador gestionPatrocinador = new GestionPatrocinador();
            gestionPatrocinador.Show();
            this.Close();
        }

    }
}
