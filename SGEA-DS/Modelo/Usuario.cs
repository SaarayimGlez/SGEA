using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [DataContract]
    public partial class Usuario
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string nombreUsuario { get; set; }

        [DataMember]
        public string contrasenia { get; set; }
    }
}
