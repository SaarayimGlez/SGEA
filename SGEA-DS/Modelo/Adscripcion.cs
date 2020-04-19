using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [DataContract]
    public partial class Adscripcion
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string ciudad { get; set; }

        [DataMember]
        public string direccion { get; set; }

        [DataMember]
        public string correoElectronico { get; set; }

        [DataMember]
        public string estado { get; set; }
    }
}
