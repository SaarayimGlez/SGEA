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
    /// Lógica de interacción para CU23_2.xaml
    /// </summary>
    public partial class CU23_2 : CtrolUsrCtrolEvento
    {
        private Modelo.MiembroComite miembroComiteModificar;
        private Modelo.MiembroComite miembroComite;

        public CU23_2(MiembroComite miembroComiteOriginal, MiembroComite usuario)
        {
            InitializeComponent();
            this.miembroComite = usuario;
            LlenarCampos(miembroComiteOriginal);
        }

        private void LlenarCampos(MiembroComite miembroComiteOriginal)
        {
            this.miembroComiteModificar = miembroComiteOriginal;

            textbox_nombre.Text = miembroComiteModificar.nombre;
            textbox_apellidoP.Text = miembroComiteModificar.apellidoPaterno;
            textbox_apellidoM.Text = miembroComiteModificar.apellidoMaterno;
            textbox_correoElectronico.Text = miembroComiteModificar.correoElectronico;
            comboBox_nivelExperiencia.Text = miembroComiteModificar.nivelExperiencia;
        }

        private bool ModificarMiembroComite()
        {
            MiembroComite_Logica miembroComite_Logica = new MiembroComite_Logica();
            if (textBlock_mensaje.Text.Equals("sin conexion") ||
                !miembroComite_Logica.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                textBlock_mensaje.Text = "Se ha perdido conexión con la base de datos";
                textBlock_mensaje.Foreground = Brushes.Red;
                textBlock_mensaje.FontWeight = FontWeights.Bold;
                return true;
            }

            MiembroComite miembroComiteActualizado = new MiembroComite()
            {
                Id = miembroComiteModificar.Id,
                nombre = textbox_nombre.Text,
                apellidoMaterno = textbox_apellidoM.Text,
                apellidoPaterno = textbox_apellidoP.Text,
                correoElectronico = textbox_correoElectronico.Text,
                nivelExperiencia =
                        (string)((ComboBoxItem)comboBox_nivelExperiencia.SelectedValue).Content
        };

            return miembroComite_Logica.ModificarMiembroComite(miembroComiteActualizado);
        }

        private void Click_Aceptar(object sender, RoutedEventArgs e)
        {
            if (textBlock_mensaje.Text.Equals("sin conexion") || ValidarDatos())
            {
                ModificarMiembroComite();
                if (!textBlock_mensaje.Text.Equals("Se ha perdido conexión con la base de datos"))
                {
                    textBlock_mensaje.Text = String.Empty;
                    var bold = new Bold(new Run("Miembro de comité modificado con éxito"));
                    textBlock_mensaje.Inlines.Add(bold);
                }
            }
            else
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(
                    new Run("Hay datos inválidos o incompletos, favor de revisar")
                    {
                        Foreground = Brushes.Red
                    });
                textBlock_mensaje.Inlines.Add(bold);
            }
        }

        private bool ValidarDatos()
        {
            if (textbox_nombre.Text.Any(char.IsDigit) |
                    textbox_nombre.Text.Any(char.IsPunctuation))
            {
                return false;
            }
            if (textbox_apellidoM.Text.Any(char.IsDigit) |
                    textbox_apellidoM.Text.Any(char.IsPunctuation))
            {
                return false;
            }
            if (textbox_apellidoP.Text.Any(char.IsDigit) |
                    textbox_apellidoP.Text.Any(char.IsPunctuation))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(textbox_nombre.Text) |
                string.IsNullOrWhiteSpace(textbox_apellidoM.Text) |
                string.IsNullOrWhiteSpace(textbox_apellidoP.Text) |
                string.IsNullOrWhiteSpace(textbox_correoElectronico.Text))
            {
                return false;
            }
            if (!Regex.IsMatch
                (textbox_correoElectronico.Text, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                return false;
            }
            return true;
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            GestionMiembroComite gestionMiembroComite =
                new GestionMiembroComite(this.miembroComite, 1);
            gestionMiembroComite.Show();
            var window = Window.GetWindow(this);
            window.Close();
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CU23_1(this.miembroComite));
        }
    }
}
