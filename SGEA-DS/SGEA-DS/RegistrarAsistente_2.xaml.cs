using Logica;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para CU26_2.xaml
    /// </summary>
    public partial class CU26_2 : CtrolUsrCtrolEvento
    {
        private MiembroComite miembroComite;
        private int actividadId;

        public CU26_2(int actividadId, MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            this.actividadId = actividadId;
        }

        private bool NuevoAsistente()
        {
            Asistente_Logica asistente_Logica = new Asistente_Logica();
            if (!asistente_Logica.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Se ha perdido conexión con la base de datos")
                {
                    Foreground = Brushes.Red
                });
                textBlock_mensaje.Inlines.Add(bold);
                return true;
            }
            Asistente nuevoAsistente = new Asistente();
            nuevoAsistente.nombre = textBox_nombre.Text;
            nuevoAsistente.apellidoPaterno = textBox_apellidoP.Text;
            nuevoAsistente.apellidoMaterno = textBox_apellidoM.Text;
            nuevoAsistente.correoElectronico = textBox_correoElectronico.Text;
            return asistente_Logica.RegistrarAsistente(nuevoAsistente, this.actividadId);
        }

        private void Click_Aceptar(object sender, RoutedEventArgs e)
        {
            if (ValidarDatos() && NuevoAsistente())
            {
                if (!textBlock_mensaje.Text.Equals("Se ha perdido conexión con la base de datos"))
                {
                    textBlock_mensaje.Text = String.Empty;
                    var bold = new Bold(new Run("Asistente registrado con éxito"));
                    textBlock_mensaje.Inlines.Add(bold);
                }
                textBox_nombre.Text = "";
                textBox_apellidoP.Text = "";
                textBox_apellidoM.Text = "";
                textBox_correoElectronico.Text = "";
            }
            else
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run(
                    "Hay datos inválidos o incompletos, favor de revisar"
                    )
                { Foreground = Brushes.Red });
                textBlock_mensaje.Inlines.Add(bold);
            }
        }

        private bool ValidarDatos()
        {
            if (textBox_nombre.Text.Any(char.IsDigit) |
                    textBox_nombre.Text.Any(char.IsPunctuation))
            {
                return false;
            }
            if (textBox_apellidoP.Text.Any(char.IsDigit) |
                    textBox_apellidoP.Text.Any(char.IsPunctuation))
            {
                return false;
            }
            if (textBox_apellidoM.Text.Any(char.IsDigit) |
                    textBox_apellidoM.Text.Any(char.IsPunctuation))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox_nombre.Text) |
                string.IsNullOrWhiteSpace(textBox_apellidoM.Text) |
                string.IsNullOrWhiteSpace(textBox_apellidoP.Text) |
                string.IsNullOrWhiteSpace(textBox_correoElectronico.Text))
            {
                return false;
            }
            if (!Regex.IsMatch
                (textBox_correoElectronico.Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                return false;
            }
            return true;
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            GestionMiembroComite gestionMiembroComite =
                new GestionMiembroComite(this.miembroComite, 2);
            gestionMiembroComite.Show();
            var window = Window.GetWindow(this);
            window.Close();
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CU26_1(this.miembroComite));
        }
    }
}
