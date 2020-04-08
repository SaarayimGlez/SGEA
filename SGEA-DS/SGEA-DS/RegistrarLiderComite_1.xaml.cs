using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Logica;

namespace SGEA_DS
{

    public partial class CU01_1 : Window
    {

        private List<string> listaComite;
        private List<RadioButton> listaRbComite;
        private Comite_Logica comiteDAO;
        private List<int> listaIdComite;
        private int eventoId;
        private string nombreEvento;
        

        public CU01_1(int eventoId, string nombreEvento)
        {
            InitializeComponent();
            this.eventoId = eventoId;
            this.nombreEvento = nombreEvento;
            this.Title = "Registrar lider de comité del evento: " + nombreEvento;
            llenarListaComite(1);
        }

        private void llenarListaComite(int eventoId)
        {
            comiteDAO = new Comite_Logica();
            if (!comiteDAO.ComprobarConexion())
            {
                textBlock_Mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Se ha perdido conexión con la base de datos")
                {
                    Foreground = Brushes.Red
                });
                textBlock_Mensaje.Inlines.Add(bold);
                button_Cancelar.Content = "Regresar";
                button_Aceptar.Visibility = Visibility.Hidden;
            }
            else
            {
                listaComite = comiteDAO.RecuperarComitesSinLider(eventoId);
                listaRbComite = new List<RadioButton>();
                listaIdComite = new List<int>();

                foreach (string comite in listaComite)
                {
                    String patronSimbolo = @"\s-\s?[+*]?\s?-\s";
                    String[] elementoComite = System.Text.RegularExpressions.Regex.Split(comite, patronSimbolo);
                    listaIdComite.Add(Convert.ToInt32(elementoComite[1]));
                    insertarFila(elementoComite[0]);
                }
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void click_Aceptar(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listaRbComite.Count; i++)
            {
                if (listaRbComite[i].IsChecked == true)
                {
                    CU01_2 win2 = new CU01_2(listaIdComite[i]);
                    win2.Show();
                    this.Close();
                }
            }
        }

        private void click_Cancelar(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(this.eventoId, this.nombreEvento);
            main.Show();
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
