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

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para EnviarEvaluacion_2.xaml
    /// </summary>
    public partial class EnviarEvaluacion_2 : Window
    {
        private List<object> articulo;
        public EnviarEvaluacion_2(String mensaje , List<object> articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            textBlock_Mensaje.Text = mensaje;
        }

        private void Button_Enviar_Click(object sender, RoutedEventArgs e)
        {
            if(textBox_Correo.Text == "" || textBox_Asunto.Text == "")
            {
                label_Mensaje.Content = "Favor de completar todos los campos";
            }
            else
            {
                Evaluacion_Logica evaluacion = new Evaluacion_Logica();
                evaluacion.SendEmail(textBox_Correo.Text, textBox_Asunto.Text, textBlock_Mensaje.Text);
                label_Mensaje.Content = "Se ha enviado el correo electrónico con éxito";
            }
        }

        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            EnviarEvaluacion evaluacion = new EnviarEvaluacion(this.articulo);
            evaluacion.Show();
            this.Close();
        }
    }
}
