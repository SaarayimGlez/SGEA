using System;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Logica;
using Modelo;

namespace SGEA_DS
{
    public partial class CU04 : VentanaCtrolEvento
    {
        private Modelo.Evento evento;

        public CU04()
        {
            InitializeComponent();
        }

        public CU04(Modelo.Evento evento)
        {
            InitializeComponent();
            this.evento = evento;
            this.Title = "Registrar comité";
        }

        private void Click_Aceptar(object sender, RoutedEventArgs e)
        {
            if (ValidarDatos() && NuevoComite())
            {
                if (!textBlock_mensaje.Text.Equals("Se ha perdido conexión con la base de datos"))
                {
                    textBlock_mensaje.Text = String.Empty;
                    var bold = new Bold(new Run("Comité registrado con éxito"));
                    textBlock_mensaje.Inlines.Add(bold);
                }
                textBox_nombre.Text = "";
                textBox_descripcion.Text = "";
            }
            else
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run(
                    "Hay datos inválidos o el comité ya existe, favor de revisar"
                    ) { Foreground = Brushes.Red });
                textBlock_mensaje.Inlines.Add(bold);
            }
        }

        private bool NuevoComite()
        {
            Modelo.Comite nuevoComite = new Modelo.Comite();
            nuevoComite.nombre = textBox_nombre.Text;
            nuevoComite.descripcion = textBox_descripcion.Text;
            nuevoComite.EventoId = evento.Id;
            Comite_Logica comiteDAO = new Comite_Logica();
            if (!comiteDAO.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Se ha perdido conexión con la base de datos")
                {
                    Foreground = Brushes.Red
                });
                textBlock_mensaje.Inlines.Add(bold);
                return true;
            }
            return comiteDAO.RegistrarComite(nuevoComite);
        }

        private bool ValidarDatos()
        {
            if (textBox_nombre.Text.Any(char.IsPunctuation) | 
                textBox_descripcion.Text.Any(char.IsPunctuation) |
                textBox_nombre.Text.Any(char.IsDigit) | textBox_descripcion.Text.Any(char.IsDigit) |
                string.IsNullOrWhiteSpace(textBox_nombre.Text) | 
                string.IsNullOrWhiteSpace(textBox_descripcion.Text))
            {
                return false;
            }
            return true;
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            GestionComite gestionComite = new GestionComite(this.evento);
            gestionComite.Show();
            this.Close();
        }

    }
}