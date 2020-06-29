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

namespace SGEA_DS {
    /// <summary>
    /// Lógica de interacción para RegistrarMiembroComite.xaml
    /// </summary>
    public partial class RegistrarMiembroComite : Window {
        private MiembroComite miembroComite;
        private List<Comite> listaComite;

        public RegistrarMiembroComite(MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            llenarCombobox();

        }
        //Para llenar el combobox con los comités 
        private void llenarCombobox()
        {
            MiembroComite_Logica miembroComite = new MiembroComite_Logica();
            if (!miembroComite.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                Comite_Logica comite = new Comite_Logica();

                this.listaComite = comite.GenerarListaComite();
                foreach (var comiteL in listaComite)
                {
                    comboBox_Comite.Items.Add(comiteL.nombre);
                }
            }
        }

        //Verifica que todos los campos estén completos.
        private bool ComprobarCampos()
        {
            if (textBox_Nombre.Text == "" || textBox_ApellidoP.Text == "" || textBox_Contrasenia.Text == "" ||
                textBox_Email.Text == "" || textBox_Experiencia.Text == "" || textBox_Usuario.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //Hace el registro del usuario del miembro de comité
        private void RegistrarUsuario()
        {
            Usuario_Logica usuario = new Usuario_Logica();
            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.nombreUsuario = textBox_Usuario.Text;
            nuevoUsuario.contrasenia = textBox_Usuario.Text;
            usuario.RegistrarUsuario(nuevoUsuario);
        }



        private void Button_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if (ComprobarCampos() == false)
            {
                label_Mensaje.Content = "Favor de completar todos los campos";
            }
            else
            {
                RegistrarUsuario();
                MiembroComite_Logica miembroComite = new MiembroComite_Logica();
                MiembroComite nuevoMiembro = new MiembroComite();
                Usuario_Logica usuario = new Usuario_Logica();
                nuevoMiembro.nombre = textBox_Nombre.Text;
                nuevoMiembro.apellidoPaterno = textBox_ApellidoP.Text;
                nuevoMiembro.apellidoMaterno = textBox_ApellidoM.Text;
                nuevoMiembro.correoElectronico = textBox_Email.Text;
                nuevoMiembro.nivelExperiencia = textBox_Experiencia.Text;
                nuevoMiembro.evaluador = false;
                nuevoMiembro.liderComite = false;
                nuevoMiembro.ComiteId = listaComite[comboBox_Comite.SelectedIndex].Id;
                nuevoMiembro.idUsuario = usuario.ComprobarUsuario(textBox_Usuario.Text, textBox_Contrasenia.Text);
                miembroComite.RegistrarMiembroComite(nuevoMiembro);
                label_Mensaje.Content = "Se ha registrado al miembo de comité con éxito";
            }
        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            MenuLiderComite menuLider = new MenuLiderComite(this.miembroComite);
            menuLider.Show();
            this.Close();
        }

        private void ComboBox_Comite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
