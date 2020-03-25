﻿using System;
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
using DataAccess;

namespace SGEA_DS {
    /// <summary>
    /// Lógica de interacción para Actividades.xaml
    /// </summary>
    public partial class Actividades: Window {
        private Evento evento;
        private int centinel;

        public Actividades() {
            InitializeComponent();
        }

        public Evento Evento { 
            get { return evento; } 
            set { evento = value;
                CargarDatos();
            } 
        }
        public int Centinel { get => centinel; set => centinel = value; }

        private void CargarDatos() {
            using (var container = new DataModelContainer()) {
                var actividades = (from actividad in container.ActividadSet
                                      orderby actividad.Id
                                   where actividad.EventoId == evento.Id
                                      select actividad).ToList();
                LBActividades.ItemsSource = actividades;
            }
        }

        private void MostrarAsistentes(object sender,MouseButtonEventArgs e) {
            if(LBActividades.SelectedItem != null) {
                Asistentes asistentes = new Asistentes();
                asistentes.Asistente = (Asistente)LBActividades.SelectedItem;
                asistentes.Show();
                this.Close();
            }
        }
    }
}
