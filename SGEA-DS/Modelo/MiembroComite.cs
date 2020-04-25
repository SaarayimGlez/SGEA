using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [DataContract]
    public partial class MiembroComite
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string apellidoPaterno { get; set; }

        [DataMember]
        public string apellidoMaterno { get; set; }

        [DataMember]
        public string correoElectronico { get; set; }

        [DataMember]
        public string nivelExperiencia { get; set; }

        [DataMember]
        public bool liderComite { get; set; }

        [DataMember]
        public int ComiteId { get; set; }

        [DataMember]
        public string nombreUsuario { get; set; }

        [DataMember]
        public string contrasenia { get; set; }

        [DataMember]
        public bool evaluador { get; set; }

    }
}
