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
using System.Windows.Shapes;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Click_Entrar(object sender, RoutedEventArgs e)
        {
            Usuario_Logica usuario_Logica = new Usuario_Logica();
            if (!string.IsNullOrWhiteSpace(textBox_usuario.Text) && 
                !string.IsNullOrWhiteSpace(textBox_contrasena.Password))
            {
                int idUsuario = usuario_Logica.ComprobarUsuario(
                    textBox_usuario.Text, textBox_contrasena.Password);
                if (idUsuario != 0)
                {
                    MiembroComite_Logica miembroComite_Logica = new MiembroComite_Logica();
                    Modelo.MiembroComite usuarioActual = 
                        miembroComite_Logica.RecuperarMiembroComite(idUsuario);
                    if (usuarioActual != null)
                    {
                        if (usuarioActual.liderComite)
                        {
                            MenuLiderComite menuLiderComite = new MenuLiderComite(usuarioActual);
                            menuLiderComite.Show();
                            this.Close();
                        }
                        else if(usuarioActual.evaluador)
                        {
                            GestionArticulo gestionArticulo = new GestionArticulo(usuarioActual);
                            gestionArticulo.Show();
                            this.Close();
                        }
                        else
                        {
                            MenuMiembroComite menuMiembroComite = new MenuMiembroComite(usuarioActual);
                            menuMiembroComite.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MenuOrganizador menuOrganizador = new MenuOrganizador();
                        menuOrganizador.Show();
                        this.Close();
                    }
                }
            }
        }

    }
}
