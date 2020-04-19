using Logica;
using Modelo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace SGEA_DS
{
    public partial class CU18_1 : CtrolUsrCtrolEvento
    {
        private List<Magistral> listaMagistral;

        public CU18_1()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            Magistral_Logica magistral_Logica = new Magistral_Logica();
            if (!magistral_Logica.ComprobarConexion())
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
                this.listaMagistral = magistral_Logica.RecuperarMagistral();
                foreach (Magistral magistral in listaMagistral)
                {
                    comboBox_magistral.Items.Add(magistral.nombre + " " + 
                        magistral.apellidoPaterno + " " + magistral.apellidoMaterno);
                }
            }
        }

        private void Combobox_Magistral_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            button_aceptar.IsEnabled = true;
        }

        private void Click_Aceptar(object sender, RoutedEventArgs e)
        {
            foreach (Magistral magistral in listaMagistral)
            {
                if (comboBox_magistral.SelectedItem.ToString().Equals(magistral.nombre + " " + 
                    magistral.apellidoPaterno + " " + magistral.apellidoMaterno))
                {
                    Switcher.Switch(new CU18_2(magistral));
                }
            }
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.Close();
        }

    }
}
