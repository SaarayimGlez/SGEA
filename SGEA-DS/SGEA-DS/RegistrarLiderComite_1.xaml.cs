﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Logica;

namespace SGEA_DS
{
    public partial class CU01_1 : UserControl
    {
        private List<RadioButton> listaRbComite;
        private List<string> listaComite;
        private Modelo.Evento evento;

        public CU01_1(Modelo.Evento evento)
        {
            InitializeComponent();
            this.evento = evento;
            LlenarListaComite(evento.Id);
        }

        private void LlenarListaComite(int eventoId)
        {
            Comite_Logica comiteDAO = new Comite_Logica();
            if (!comiteDAO.ComprobarConexion())
            {
                textBlock_mensaje.Text = String.Empty;
                var bold = new Bold(new Run("Se ha perdido conexión con la base de datos")
                {
                    Foreground = Brushes.Red
                });
                textBlock_mensaje.Inlines.Add(bold);
                button_cancelar.Content = "Regresar";
                button_aceptar.Visibility = Visibility.Hidden;
            }
            else
            {
                this.listaComite = comiteDAO.RecuperarComitesSinLider(eventoId);
                listaRbComite = new List<RadioButton>();

                foreach (string comite in listaComite)
                {
                    String patronSimbolo = @"\s-\s?[+*]?\s?-\s";
                    String[] elementoComite = 
                        System.Text.RegularExpressions.Regex.Split(comite, patronSimbolo);
                    InsertarFila(elementoComite[0]);
                }
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Click_Aceptar(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listaRbComite.Count; i++)
            {
                if (listaRbComite[i].IsChecked == true)
                {
                    Switcher.Switch(new CU01_2(listaComite[i], this.evento));
                }
            }
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            GestionComite gestionComite = new GestionComite(this.evento);
            gestionComite.Show();
            var window = Window.GetWindow(this);
            window.Close();
        }

        
        private void InsertarFila(string comite)
        {
            GridPrincipal.RowDefinitions.Insert(
                GridPrincipal.RowDefinitions.Count, new RowDefinition());
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
