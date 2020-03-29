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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SGEA_DS {
    public partial class CU38 : Window {

        public CU38()
        {
            InitializeComponent();
            llenarListaPatrocinadores();
            ToolTipService.ShowDurationProperty.OverrideMetadata(
                typeof(DependencyObject), new FrameworkPropertyMetadata(Int32.MaxValue));
        }

        private void llenarListaPatrocinadores()
        {
            List<Patrocinador> listaPatrocinador = new List<Patrocinador>();

            /**/
            Patrocinador patrocinador1 = new Patrocinador();
            Patrocinador patrocinador2 = new Patrocinador();
            Patrocinador patrocinador3 = new Patrocinador();
            Patrocinador patrocinador4 = new Patrocinador();
            patrocinador1.nombre = "nombre1";
            patrocinador1.apellidoPaterno = "apelldio1";
            patrocinador1.apellidoMaterno = "apellido12";
            patrocinador1.correoElectronico = "correo1";
            patrocinador1.empresa = "empresa1";
            patrocinador1.direccion = "dir1";
            patrocinador1.numeroTelefono = "1";
            patrocinador2.nombre = "nombre2";
            patrocinador2.apellidoPaterno = "apelldio2";
            patrocinador2.apellidoMaterno = "apellido22";
            patrocinador2.correoElectronico = "correo2";
            patrocinador2.empresa = "empresa2";
            patrocinador2.direccion = "dir2";
            patrocinador2.numeroTelefono = "2";
            listaPatrocinador.Add(patrocinador1);
            listaPatrocinador.Add(patrocinador2);
            /**/

            for (int i = 0; i < listaPatrocinador.Count; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    insertarParticipante(listaPatrocinador[i], 0);
                } else
                {
                    insertarParticipante(listaPatrocinador[i], 1);
                }
            }
        }

        private void insertarParticipante(Patrocinador patrocinador, int column)
        {
            if (column == 0)
            {
                grid_Patrocinadores.RowDefinitions.Add(new RowDefinition());
            }
            int row = grid_Patrocinadores.RowDefinitions.Count - 1;
            var rectangulo = new Rectangle();
            var lblPatrocinador = new Label();
            var spToolTip = new StackPanel();
            lblPatrocinador.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            lblPatrocinador.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            lblPatrocinador.FontSize = 20;
            
            spToolTip.Children.Add(new TextBlock() { Text = "Nombre:\t\t" + patrocinador.nombre });
            spToolTip.Children.Add(new TextBlock() { Text = "Apellido paterno:\t" + patrocinador.apellidoPaterno });
            spToolTip.Children.Add(new TextBlock() { Text = "Apellido materno:\t" + patrocinador.apellidoMaterno });
            spToolTip.Children.Add(new TextBlock() { Text = "Correo electrónico:" + patrocinador.correoElectronico });
            spToolTip.Children.Add(new TextBlock() { Text = "Direccion:\t  " + patrocinador.direccion });
            spToolTip.Children.Add(new TextBlock() { Text = "Numweo telefónico:" + patrocinador.numeroTelefono });

            ToolTip tooltip = new ToolTip { Content = spToolTip };
            rectangulo.ToolTip = tooltip;
            if (!tooltip.IsOpen) tooltip.StaysOpen = true;

            rectangulo.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ad76ad"));
            rectangulo.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            rectangulo.StrokeThickness = 2;
            grid_Patrocinadores.Children.Add(rectangulo);
            Grid.SetRow(rectangulo, row);
            Grid.SetColumn(rectangulo, column);

            lblPatrocinador.Content = patrocinador.empresa;
            grid_Patrocinadores.Children.Add(lblPatrocinador);
            Grid.SetRow(lblPatrocinador, row);
            Grid.SetColumn(lblPatrocinador, column);
        }

        private void click_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
