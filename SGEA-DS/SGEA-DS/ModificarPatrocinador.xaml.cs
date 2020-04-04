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
using DataAccess;
using System.Text.RegularExpressions;

namespace SGEA_DS {
    /// <summary>
    /// Lógica de interacción para ModificarPatrocinador.xaml
    /// </summary>
    public partial class ModificarPatrocinador: Window {
        private Patrocinador editable;

        public ModificarPatrocinador() {
            InitializeComponent();
        }

        public Patrocinador Editable { 
            get { return editable; }
            set {
                editable = value;
                TBNombre.Text = editable.nombre;
                TBPaterno.Text = editable.apellidoPaterno;
                TBMaterno.Text = editable.apellidoMaterno;
                TBCorreo.Text = editable.correoElectronico;
                TBDireccion.Text = editable.direccion;
                TBEmpresa.Text = editable.empresa;
                TBTelefono.Text = editable.numeroTelefono;
            } 
        }

        private void GuardarPatrocinador(object sender,RoutedEventArgs e) {
            try {
                if (ValidarDatos()) {
                    using (var container = new DataModelContainer()) {
                        var result = container.PatrocinadorSet.SingleOrDefault(patrocinador => patrocinador.Id == editable.Id);
                        if (result != null) {
                            result.nombre = TBNombre.Text;
                            result.apellidoPaterno = TBPaterno.Text;
                            result.apellidoMaterno = TBMaterno.Text;
                            result.correoElectronico = TBCorreo.Text;
                            result.direccion = TBDireccion.Text;
                            result.empresa = TBEmpresa.Text;
                            container.SaveChanges();
                        }
                    }
                } else {
                    LBMensaje.Content = "Los datos son incorrectos, por favor verifique su información";
                    return;
                }
            } catch (Exception) {
                LBMensaje.Content = "No hay conexión a la base de datos, inténtelo más tarde";
                return;
            }
            LBMensaje.Content = "Operación realizada con éxito";
        }

        private void CancelarModificacion(object sender,RoutedEventArgs e) {
            VentanaPrincipal main = new VentanaPrincipal();
            main.Show();
            this.Close();
        }

        private bool ValidarDatos() {
            bool validacion = true;
            if (!string.IsNullOrEmpty(TBNombre.Text)) {
                foreach (char caracter in TBNombre.Text) {
                    if (!char.IsLetter(caracter)) {
                        validacion = false;
                    }
                }
            } else {
                validacion = false;
            }
            if (!string.IsNullOrEmpty(TBPaterno.Text)) {
                foreach (char caracter in TBPaterno.Text) {
                    if (!char.IsLetter(caracter)) {
                        validacion = false;
                    }
                }
            } else {
                validacion = false;
            }
            if (!string.IsNullOrEmpty(TBMaterno.Text)) {
                foreach (char caracter in TBMaterno.Text) {
                    if (!char.IsLetter(caracter)) {
                        validacion = false;
                    }
                }
            } else {
                validacion = false;
            }
            if (!string.IsNullOrEmpty(TBTelefono.Text)) {
                foreach (char caracter in TBTelefono.Text) {
                    if (!char.IsDigit(caracter)) {
                        validacion = false;
                    }
                }
            } else {
                validacion = false;
            }
            validacion = ComprobarFormatoEmail();
            if (!string.IsNullOrEmpty(TBDireccion.Text)) {
                foreach (char caracter in TBDireccion.Text) {
                    if (!char.IsLetter(caracter) && !char.IsDigit(caracter) && caracter != '#' && caracter != ' ' && caracter != '.' && caracter != ',') {
                        validacion = false;
                    }
                }
            } else {
                validacion = false;
            }
            if (!string.IsNullOrEmpty(TBEmpresa.Text)) {
                foreach (char caracter in TBEmpresa.Text) {
                    if (!char.IsLetter(caracter) && caracter != ' ') {
                        validacion = false;
                    }
                }
            } else {
                validacion = false;
            }
            return validacion;
        }

        public bool ComprobarFormatoEmail() {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(TBCorreo.Text,sFormato)) {
                if (Regex.Replace(TBCorreo.Text,sFormato,String.Empty).Length == 0) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }
    }
}
