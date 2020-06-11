using Logica;
using Modelo;
using System;
using System.Collections.Generic;
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

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para CU29.xaml
    /// </summary>
    public partial class CU29 : Window
    {
        private MiembroComite miembroComite;
        private string rutaArticulo;
        private List<List<string>> listaAutor;

        public CU29(MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            Autor_Logica autor_Logica = new Autor_Logica();
            if (!autor_Logica.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(
                    new Run("Se ha perdido conexión con la base de datos")
                    {
                        Foreground = Brushes.Red
                    });
                textBlock_mensaje.Inlines.Add(bold);
            }
            else
            {
                this.listaAutor = autor_Logica.RecuperarAutor();
                foreach (var autor in listaAutor)
                {
                    string nombreCompleto = autor[0] + " " + autor[1] + " " + autor[2];
                    comboBox_autor.Items.Add(new CheckBox() { Content = nombreCompleto });
                }
            }
        }

        private void Checkbox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            comboBox_autor.SelectedItem = null;
        }

        private void Click_Aceptar(object sender, RoutedEventArgs e)
        {
            if (ValidarDatos() && NuevoArticulo())
            {
                if (!textBlock_mensaje.Text.Equals("Se ha perdido conexión con la base de datos"))
                {
                    textBlock_mensaje.Text = String.Empty;
                    var bold = new Bold(new Run("Artículo registrado con éxito"));
                    textBlock_mensaje.Inlines.Add(bold);
                }
                textBox_titulo.Text = "";
                textBox_keyword.Text = "";
                textBox_abstract.Text = "";
                textBlock_subirDocumento.Text = "Subir documento";
                for (int i = 0; i < comboBox_autor.Items.Count; i++)
                {
                    if (((CheckBox)comboBox_autor.Items[i]).IsChecked == true)
                    {
                        ((CheckBox)comboBox_autor.Items[i]).IsChecked = false;
                    }
                }
            }
            else
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run(
                    "Hay datos incompletos, favor de revisar"
                    )
                { Foreground = Brushes.Red });
                textBlock_mensaje.Inlines.Add(bold);
            }
        }

        private bool NuevoArticulo()
        {
            Articulo_Logica articulo_Logica = new Articulo_Logica();
            if (!articulo_Logica.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Se ha perdido conexión con la base de datos")
                {
                    Foreground = Brushes.Red
                });
                textBlock_mensaje.Inlines.Add(bold);
                return true;
            }
            Articulo nuevoArticulo = new Articulo();
            nuevoArticulo.titulo = textBox_titulo.Text;
            nuevoArticulo.keyword = textBox_keyword.Text;
            nuevoArticulo.@abstract = textBox_abstract.Text;
            nuevoArticulo.documento = this.rutaArticulo;
            nuevoArticulo.status = false;

            List<int> autorId = new List<int>();
            for (int i = 0; i < comboBox_autor.Items.Count; i++)
            {
                if (((CheckBox)comboBox_autor.Items[i]).IsChecked == true)
                {
                    foreach (List<string> autor in listaAutor)
                    {
                        if (((CheckBox)comboBox_autor.Items[i]).Content.ToString()
                            .Equals(autor[0] + " " + autor[1] + " " + autor[2]))
                        {
                            autorId.Add(Convert.ToInt32(autor[5]));
                        }
                    }
                }
            }

            return articulo_Logica.RegistrarArticulo(nuevoArticulo, autorId);
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(textBox_titulo.Text) |
                string.IsNullOrWhiteSpace(textBox_keyword.Text) |
                string.IsNullOrWhiteSpace(textBox_abstract.Text))
            {
                return false;
            }
            if (textBlock_subirDocumento.Text == "Subir documento")
            {
                return false;
            }
            for (int i = 0; i < comboBox_autor.Items.Count; i++)
            {
                if (((CheckBox)comboBox_autor.Items[i]).IsChecked == true)
                {
                    return true;
                }
            }
            return false;
        }

        private void Click_SubirDocumento(object sender, RoutedEventArgs e)
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
                        textBlock_subirDocumento.Text = rutaArchivo.Last<string>();
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

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            GestionAutorArticulo gestionAutorArticulo = 
                new GestionAutorArticulo(this.miembroComite);
            gestionAutorArticulo.Show();
            this.Close();
        }
    }
}
