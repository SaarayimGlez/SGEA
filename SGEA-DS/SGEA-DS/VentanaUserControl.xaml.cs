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
    /// Lógica de interacción para VentanaUserControl.xaml
    /// </summary>
    public partial class VentanaUserControl : Window
    {
        public VentanaUserControl(Modelo.Evento evento)
        {
            InitializeComponent();
            Switcher.pageSwitcher = this;
            Switcher.Switch(new CU01_1(evento));
        }

        public VentanaUserControl(int ventanaCU)
        {
            InitializeComponent();
            Switcher.pageSwitcher = this;
            if (ventanaCU == 38)
            {
                this.Title = "Consultar patrocinadores";
                Switcher.Switch(new CU38());

            }
            if (ventanaCU == 12)
            {
                this.Title = "Consultar";
                Switcher.Switch(new CU38());

            }
            else
            {
                this.Title = "Modificar magistral";
                //Switcher.Switch(new CU18());
            }
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }
    }
}