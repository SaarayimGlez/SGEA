using System;
using System.Linq;
using System.Windows;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para RegistrarEvento.xaml
    /// </summary>
    public partial class RegistrarEvento : Window
    {
        /*private int eventoId;

        public RegistrarEvento()
        {
            InitializeComponent();
        }

        private void GuardarEvento(object sender, RoutedEventArgs e)
        {
            Evento nuevo = new Evento();
            if (ValidarDatos()) { 
                nuevo.nombre = TBnombre.Text;
                nuevo.fechaInicio = (DateTime)DPinicio.SelectedDate;
                nuevo.fechaFin = (DateTime)DPfin.SelectedDate;
                nuevo.institucionOrganizadora = CBinstitucion.Text;
                nuevo.lugar = TBlugar.Text;
            } else
            {
                LBMensage.Content = "Los datos son incorrectos, por favor verifique su información*";
                return;
            }
            try {
                DataModelContainer container = new DataModelContainer();
                container.EventoSet.Add(nuevo);
                container.SaveChanges();
                var eventoRegistrado = container.EventoSet.ToList();
                eventoId = eventoRegistrado[eventoRegistrado.Count - 1].Id;
                LBMensage.Content = "Evento creado con éxito*";
                button_Cancelar.Content = "Regresar";
                button_Aceptar.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                LBMensage.Content = "No hay conexión a la base de datos, inténtelo más tarde";
                MessageBox.Show(ex.Message,e.GetType().ToString());
            }
        }

        private void CancelarEvento(object sender, RoutedEventArgs e)
        {
            MainWindow main;
            if ((button_Cancelar.Content as string) == "Regresar")
            {
                main = new MainWindow(eventoId, TBnombre.Text);
                main.Show();
                this.Close();
            } else
            {
                main = new MainWindow();
                main.Show();
                this.Close();
            }
        }

        private bool ValidarDatos()
        {
            bool centinel = true;
            if (!string.IsNullOrEmpty(TBnombre.Text))
            {
                foreach(char caracter in TBnombre.Text)
                {
                    if (!char.IsLetter(caracter))
                    {
                        centinel = false;
                    }
                }
            }
            else
            {
                centinel = false;
            }
            if (string.IsNullOrEmpty(DPinicio.SelectedDate.ToString()))
            {
                centinel = false;
            }
            if (string.IsNullOrEmpty(DPfin.SelectedDate.ToString()))
            {
                centinel = false;
            }
            if (CBinstitucion.SelectedIndex < 0)
            {
                centinel = false;
            }
            if (!string.IsNullOrEmpty(TBlugar.Text))
            {
                foreach (char caracter in TBlugar.Text)
                {
                    if (!char.IsLetter(caracter))
                    {
                        centinel = false;

                    }
                }
            }
            else
            {
                centinel = false;
            }
            return centinel;
        }*/
    }
}
