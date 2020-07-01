using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using Modelo;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para RegistrarPagoArticulo.xaml
    /// </summary>
    public partial class RegistrarPagoArticulo : Window
    {
        Modelo.MiembroComite miembroComite;
        private string rutaArticulo;
        private List<List<string>> listaAutor;

        public RegistrarPagoArticulo(Modelo.MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            LlenarCombobox();
        }

        private void LlenarCombobox()
        {
            Autor_Logica autor_Logica = new Autor_Logica();
            if (!autor_Logica.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listaAutor = autor_Logica.RecuperarAutor();
                foreach (var autor in listaAutor)
                {
                    string nombreCompleto = autor[0] + " " + autor[1] + " " + autor[2];
                    comboBox_Autor.Items.Add(nombreCompleto);
                }
            }
        }

        private bool ComprobarCampos()
        {
            if (textbox_archivo.Text == "" || textBox_Fecha.Text == "" || textBox_Hora.Text == "" || TextBox_Pago.Text == "" || comboBox_Autor.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Button_Click_SubirA(object sender, RoutedEventArgs e)
        {
            Stream checkStream = null;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "Archivos Word|*.docx;*.doc|Archivos PDF|*.pdf";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                try
                {
                    if ((checkStream = dlg.OpenFile()) != null)
                    {
                        string filename = dlg.FileName;
                        this.rutaArticulo = filename;
                        String[] rutaArchivo = filename.Split('\\');
                        textbox_archivo.Text = rutaArchivo.Last<string>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Problem occured, try again later");
            }
        }

        private void Button_Click_Guardar(object sender, RoutedEventArgs e)
        {
            if (ComprobarCampos() == false)
            {
                label_Mensaje.Content = "Favor de completar todos los campos";
            }
            else
            {
                RegistroArticulo_Logica registroArticulo = new RegistroArticulo_Logica();
                if (!registroArticulo.ComprobarConexion())
                {
                    label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";

                }
                else
                {
                    RegistroArticulo registro = new RegistroArticulo();
                    registro.cantidadPago = float.Parse(TextBox_Pago.Text, NumberFormatInfo.InvariantInfo);
                    registro.fecha = Convert.ToDateTime(textBox_Fecha.Text);
                    registro.hora = textBox_Hora.Text;
                    registro.comprobantePago = this.rutaArticulo;
                    registroArticulo.RegistrarPagoArticulo(registro);
                    label_Mensaje.Content = "Se ha registrado el pago con exito";
                }
            }
        }

        private void Button_Click_Cancelar(object sender, RoutedEventArgs e)
        {
            GestionAutorArticulo gestionAutorArticulo = new GestionAutorArticulo(this.miembroComite);
            gestionAutorArticulo.Show();
            this.Close();
        }

        private void ComboBox_Autor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBox_Autor.SelectedItem = null;
        }
    }
}
