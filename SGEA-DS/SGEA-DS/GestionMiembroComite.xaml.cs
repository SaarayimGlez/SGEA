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
    /// Lógica de interacción para GestionMiembroComite.xaml
    /// </summary>
    public partial class GestionMiembroComite : Window
    {
        private Modelo.MiembroComite miembroComite;

        public GestionMiembroComite(Modelo.MiembroComite miembroComite, int codigoVentana)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            switch (codigoVentana)
            {
                case 1:
                    button_registrar.Content = "Agregar a comité";
                    button_registrar.Click += Click_AgregarAComite;
                    button_modificar.Content = "Modificar";
                    button_modificar.Click += Click_ModificarMiembroComite;
                    this.Title = "Gestion de miembro de comité";
                    button_regresar.Click += Click_RegresarLiderC;
                    break;
                case 2:
                    button_registrar.Content = "Registrar";
                    button_registrar.Click += Click_RegistrarAsistente;
                    button_modificar.Content = "Modificar";
                    button_modificar.Click += Click_ModificarAsistente;
                    this.Title = "Gestion de asistente";
                    button_regresar.Click += Click_RegresarMiembroC;
                    break;
                case 3:
                    button_registrar.Content = "Registrar";
                    button_registrar.Click += Click_RegistrarMagistral;
                    button_modificar.Content = "Modificar";
                    button_modificar.Click += Click_ModificarMagistral;
                    this.Title = "Gestion de magistral";
                    button_regresar.Click += Click_RegresarMiembroC;
                    break;
                case 4:
                    button_registrar.Content = "Registrar";
                    button_registrar.Click += Click_RegistrarParticipante;
                    button_modificar.Content = "Modificar";
                    button_modificar.Click += Click_ModificarParticipante;
                    this.Title = "Gestion de participante";
                    button_regresar.Click += Click_RegresarMiembroC;
                    break;
                case 5:
                    button_registrar.Content = "Registrar";
                    button_registrar.Click += Click_RegistrarAdscripcion;
                    button_modificar.Content = "Modificar";
                    button_modificar.Click += Click_ModificarAdscripcion;
                    this.Title = "Gestion de adscripción";
                    button_regresar.Click += Click_RegresarMiembroC;
                    break;
            }
        }

        private void Click_RegresarLiderC(object sender, RoutedEventArgs e)
        {
            MenuLiderComite gestionLiderComite = new MenuLiderComite(this.miembroComite);
            gestionLiderComite.Show();
            this.Close();
        }

        private void Click_RegresarMiembroC(object sender, RoutedEventArgs e)
        {
            MenuMiembroComite menuMiembroComite = new MenuMiembroComite(this.miembroComite);
            menuMiembroComite.Show();
            this.Close();
        }

        private void Click_AgregarAComite(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Click_ModificarMiembroComite(object sender, RoutedEventArgs e)
        {
            VentanaUserControl modificarMiembroComite =
                new VentanaUserControl(23, this.miembroComite);
            modificarMiembroComite.Show();
            this.Close();
        }

        private void Click_RegistrarAsistente(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Click_ModificarAsistente(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Click_RegistrarMagistral(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Click_ModificarMagistral(object sender, RoutedEventArgs e)
        {
            VentanaUserControl consultarPatrocinador =
                new VentanaUserControl(18, this.miembroComite);
            consultarPatrocinador.Show();
            this.Close();
        }

        private void Click_RegistrarParticipante(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Click_ModificarParticipante(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Click_RegistrarAdscripcion(object sender, RoutedEventArgs e)
        {
            /*CU44 registrarAdscripcion = new CU44(this.miembroComite);
            registrarAdscripcion.Show();
            this.Close();*/
        }

        private void Click_ModificarAdscripcion(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
