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
using System.Windows.Shapes;

namespace SGEA_DS
{
    /// <summary>
    /// Lógica de interacción para CU21.xaml
    /// </summary>
    public partial class CU21 : Window
    {
        private Modelo.MiembroComite miembroComite;
        private List<Modelo.MiembroComite> listaMiembroC;
        private List<string> listaAsistente;
        private List<List<string>> listaParticipante;
        private List<List<string>> listaMagistral;
        private List<List<string>> listaAutor;
        private Modelo.Evento eventosUsuario;

        public CU21(Modelo.MiembroComite miembroComite)
        {
            InitializeComponent();
            this.miembroComite = miembroComite;
            llenarComboBox();
        }

        private void llenarComboBox()
        {
            Evento_Logica evento_Logica = new Evento_Logica();
            this.eventosUsuario = 
                evento_Logica.RecuperarEventos(this.miembroComite.ComiteId).First<Modelo.Evento>();
            MiembroComite_Logica miembroComite_Logica = new MiembroComite_Logica();
            Asistente_Logica asistente_Logica = new Asistente_Logica();
            Participante_Logica participante_Logica = new Participante_Logica();
            Magistral_Logica magistral_Logica = new Magistral_Logica();
            Autor_Logica autor_Logica = new Autor_Logica();

            this.listaMiembroC = 
                miembroComite_Logica.RecuperarMiembroComitePorEvento(eventosUsuario.Id);
            this.listaAsistente =
                asistente_Logica.RecuperarAsistenteEvento(eventosUsuario.Id);
            this.listaParticipante =
                    participante_Logica.RecuperarParticipanteEvento(eventosUsuario.Id);
            this.listaMagistral =
                    magistral_Logica.RecuperarMagistralEvento(eventosUsuario.Id);
            this.listaAutor =
                    autor_Logica.RecuperarAutorEvento(eventosUsuario.Id);

            foreach (Modelo.MiembroComite miembro in listaMiembroC)
            {
                string nombreCompleto = miembro.nombre + " " + miembro.apellidoPaterno +
                    " " + miembro.apellidoMaterno;
                comboBox_miembroComite.Items.Add(new CheckBox() { Content = nombreCompleto });
            }
            foreach (string asistenteNombre in listaAsistente)
            {
                comboBox_asistente.Items.Add(new CheckBox() { Content = asistenteNombre });
            }
            foreach (List<string> participante in listaParticipante)
            {
                comboBox_participante.Items.Add(new CheckBox() { Content = participante[0] });
            }
            foreach (List<string> magistral in listaMagistral)
            {
                comboBox_magistral.Items.Add(new CheckBox() { Content = magistral[0] });
            }
            foreach (List<string> autor in listaAutor)
            {
                comboBox_autor.Items.Add(new CheckBox() { Content = autor[0] });
            }
        }

        private void Click_Descargar(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
            descargarMiembroComiteGafete();
            descargarAsistenteGafete();
            descargaParticipanteDiploma();
            descargarMagistralDiploma();
            descargarAutorDiploma();
            this.Topmost = false;
        }

        private void descargarAutorDiploma()
        {
            if (checkBox_autor.IsChecked == true)
            {
                foreach (List<string> autor in listaAutor)
                {
                    Diploma diploma = new Diploma(autor, eventosUsuario);
                    diploma.Show();
                }
            }
            else
            {
                for (int i = 0; i < comboBox_autor.Items.Count; i++)
                {
                    if (((CheckBox)comboBox_autor.Items[i]).IsChecked == true)
                    {
                        foreach (List<string> autor in listaAutor)
                        {
                            if (((CheckBox)comboBox_autor.Items[i]).Content.ToString()
                                .Equals(autor[0]))
                            {
                                Diploma diploma = new Diploma(autor, eventosUsuario);
                                diploma.Show();
                            }
                        }
                    }
                }
            }
        }

        private void descargarMagistralDiploma()
        {
            if (checkBox_magistral.IsChecked == true)
            {
                foreach (List<string> magistral in listaMagistral)
                {
                    Diploma diploma = new Diploma(magistral, eventosUsuario);
                    diploma.Show();
                }
            }
            else
            {
                for (int i = 0; i < comboBox_magistral.Items.Count; i++)
                {
                    if (((CheckBox)comboBox_magistral.Items[i]).IsChecked == true)
                    {
                        foreach (List<string> magistral in listaMagistral)
                        {
                            if (((CheckBox)comboBox_magistral.Items[i]).Content.ToString()
                                .Equals(magistral[0]))
                            {
                                Diploma diploma = new Diploma(magistral, eventosUsuario);
                                diploma.Show();
                            }
                        }
                    }
                }
            }
        }

        private void descargaParticipanteDiploma()
        {
            if (checkBox_participante.IsChecked == true)
            {
                foreach (List<string> participante in listaParticipante)
                {
                    Diploma diploma = new Diploma(participante, eventosUsuario);
                    diploma.Show();
                }
            }
            else
            {
                for (int i = 0; i < comboBox_participante.Items.Count; i++)
                {
                    if (((CheckBox)comboBox_participante.Items[i]).IsChecked == true)
                    {
                        foreach (List<string> participante in listaParticipante)
                        {
                            if (((CheckBox)comboBox_participante.Items[i]).Content.ToString()
                                .Equals(participante[0]))
                            {
                                Diploma diploma = new Diploma(participante, eventosUsuario);
                                diploma.Show();
                            }
                        }
                    }

                }
            }
        }

        private void descargarAsistenteGafete()
        {
            if (checkBox_asistente.IsChecked == true)
            {
                foreach (string asistenteNombre in listaAsistente)
                {
                    Gafete gafete = new Gafete(asistenteNombre);
                    gafete.Show();
                }
            }
            else
            {
                for (int i = 0; i < comboBox_asistente.Items.Count; i++)
                {
                    if (((CheckBox)comboBox_asistente.Items[i]).IsChecked == true)
                    {
                        Gafete gafete = 
                            new Gafete(((CheckBox)comboBox_asistente.Items[i]).Content.ToString());
                        gafete.Show();
                    }

                }
            }
        }

        private void descargarMiembroComiteGafete()
        {
            if (checkBox_miembroComite.IsChecked == true)
            {
                foreach (Modelo.MiembroComite miembro in listaMiembroC)
                {
                    string nombreCompleto = miembro.nombre + " " + miembro.apellidoPaterno +
                        " " + miembro.apellidoMaterno;
                    Gafete gafete = new Gafete(nombreCompleto);
                    gafete.Show();
                }
            }
            else
            {
                for (int i = 0; i < comboBox_miembroComite.Items.Count; i++)
                {
                    if (((CheckBox)comboBox_miembroComite.Items[i]).IsChecked == true)
                    {
                        Gafete gafete = 
                            new Gafete(((CheckBox)comboBox_miembroComite.Items[i]).Content.ToString());
                        gafete.Show();
                    }

                }
            }
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            MenuMiembroComite menuMiembroComite = new MenuMiembroComite(this.miembroComite);
            menuMiembroComite.Show();
            this.Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
        }
    }
}
