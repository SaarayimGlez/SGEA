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

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para CambiarContrasenia.xaml
    /// </summary>
    public partial class CambiarContrasenia : Window
    {
        private Modelo.MiembroComite miembroComite;
        public CambiarContrasenia(Modelo.MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
        }

        private bool ValidarCampos()
        {
            if(textBox_nombreUsuario.Text=="" || password_ConfirmarC.Password=="" || password_ContraseniaA.Password == "" ||
                password_ContraseniaN.Password == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Button_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCampos() == false)
            {
                label_Mensaje.Content = "Favor de completar todos los campos";
            }
            else
            {
                if(password_ContraseniaN.Password!= password_ConfirmarC.Password)
                {
                    label_Mensaje.Content = "Las contraseñas no coinciden";
                }
                else
                {
                    Usuario_Logica usuario = new Usuario_Logica();
                    usuario.CambiarContrasenia(textBox_nombreUsuario.Text, password_ContraseniaA.Password, password_ContraseniaN.Password);
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
            }
        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
