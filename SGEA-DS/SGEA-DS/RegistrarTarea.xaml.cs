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
using Modelo;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para RegistrarTarea.xaml
    /// </summary>
    public partial class RegistrarTarea : Window
    {
        Modelo.MiembroComite miembroComite;
        private List<Actividad> listaActividades;

        public RegistrarTarea(Modelo.MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            LlenarCombobox();
        }

        private void LlenarCombobox()
        {
            Actividad_Logica actividadLogica = new Actividad_Logica();
            if (!actividadLogica.ComprobarConexion())
            {
                label_Mensaje.Content = "Se ha perdido la conexión con la base de datos";
            }
            else
            {
                this.listaActividades = actividadLogica.RecuperarListaActividades();
                foreach(Actividad actividadN in listaActividades)
                {
                    comboBox_Actividad.Items.Add(actividadN.nombre);
                }
            }
        }

        private bool ComprobarDatos()
        {
            if(comboBox_Actividad.Text==""|| textBloc_Descripcion.Text=="" || textBox_Nombre.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Button_Guardar_Click(object sender, RoutedEventArgs e)
        {
            if(ComprobarDatos() == false)
            {
                label_Mensaje.Content = "Favor de completar todos los campos";
            }
            else
            {
                Tarea_Logica tarea_Logica = new Tarea_Logica();
                Modelo.Tarea tarea = new Modelo.Tarea();
                tarea.nombre = textBox_Nombre.Text;
                tarea.descripcion = textBloc_Descripcion.Text;
                tarea.actividadId = listaActividades[comboBox_Actividad.SelectedIndex].Id;
                tarea_Logica.RegistrarTarea(tarea);
                label_Mensaje.Content = "Se ha registrado la tarea con éxito";
            }
        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            MenuLiderComite menuLiderComite = new MenuLiderComite(this.miembroComite);
            menuLiderComite.Show();
            this.Close();
        }
    }
}
