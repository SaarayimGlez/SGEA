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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccess;

namespace SGEA_DS {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class CU01_1 : Window {

        private List<Comite> listaComite;
        private List<RadioButton> listaRbComite;
        //private DAOComite daoComite;

        public CU01_1()
        {
            InitializeComponent();
            llenarListaComite();
        }

        private void llenarListaComite()
        {
            /*daoComite = new DAOComite();
            listaComite = daoComite.GetComites();*/
            listaRbComite = new List<RadioButton>();

            listaComite = new List<Comite>();
            Comite comitePrueba1 = new Comite();
            comitePrueba1.nombre = "Comité de promoción";
            Comite comitePrueba2 = new Comite();
            comitePrueba2.nombre = "Comité de evaluación";
            listaComite.Add(comitePrueba1);
            listaComite.Add(comitePrueba2);
            /**/

            foreach (Comite comite in listaComite)
            {
                insertarFila(comite.nombre);
            }
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void click_Aceptar(object sender, RoutedEventArgs e)
        {
            foreach (RadioButton rbComite in listaRbComite)
            {
                if (rbComite.IsChecked == true)
                {
                    CU01_2 win2 = new CU01_2(Convert.ToString(rbComite.Content));
                    win2.Show();
                    this.Close();
                }
            }
        }

        private void click_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        private void insertarFila(string comite)
        {
            GridPrincipal.RowDefinitions.Insert(GridPrincipal.RowDefinitions.Count, new RowDefinition());
            var rbComite = new RadioButton();
            rbComite.Content= comite;
            rbComite.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            rbComite.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            rbComite.Height = 18;
            rbComite.Width = 350;
            rbComite.RenderTransformOrigin = new Point(0.5, 0.5);
            rbComite.FontSize = 14;
            TransformGroup transformGroupRb = new TransformGroup();
            transformGroupRb.Children.Add(new ScaleTransform(2, 2));
            rbComite.RenderTransform = transformGroupRb;
            GridPrincipal.Children.Add(rbComite);
            Grid.SetRow(rbComite, GridPrincipal.RowDefinitions.Count - 1);
            listaRbComite.Add(rbComite);
        } 
        
    }
}
