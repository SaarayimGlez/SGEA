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

namespace SGEA_DS {
    /// <summary>
    /// Interaction logic for RegistrarPresupuesto.xaml
    /// </summary>
    public partial class RegistrarPresupuesto: Window {
        private int centinela;
        private Evento Evento;
        public RegistrarPresupuesto(int centinel, Evento evento) {
            InitializeComponent();

            this.centinela = centinel;
            this.Evento = evento;
        }
    }
}
