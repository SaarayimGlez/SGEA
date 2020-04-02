﻿using DataAccess;
using Logica;
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
            llenarListaPatrocinadores(2);
            ToolTipService.ShowDurationProperty.OverrideMetadata(
                typeof(DependencyObject), new FrameworkPropertyMetadata(Int32.MaxValue));
        }

        private void llenarListaPatrocinadores(int eventoId)
        {
            PatrocinadorDAO patrocinadorDAO = new PatrocinadorDAO();
            List<Patrocinador> listaPatrocinador = patrocinadorDAO.RecuperarPatrocinador(eventoId);

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
            
            spToolTip.Children.Add(new TextBlock() { Text = "Nombre:\t\t  " + patrocinador.nombre });
            spToolTip.Children.Add(new TextBlock() { Text = "Apellido paterno:\t  " + patrocinador.apellidoPaterno });
            spToolTip.Children.Add(new TextBlock() { Text = "Apellido materno:\t  " + patrocinador.apellidoMaterno });
            spToolTip.Children.Add(new TextBlock() { Text = "Correo electrónico: " + patrocinador.correoElectronico });
            spToolTip.Children.Add(new TextBlock() { Text = "Direccion:\t   " + patrocinador.direccion });
            spToolTip.Children.Add(new TextBlock() { Text = "Numweo telefónico: " + patrocinador.numeroTelefono });

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