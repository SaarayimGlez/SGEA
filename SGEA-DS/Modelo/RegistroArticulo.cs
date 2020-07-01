using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelo {
    [DataContract]
    public partial class RegistroArticulo {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public String comprobantePago { get; set; }

        [DataMember]
        public System.DateTime fecha { get; set; }

        [DataMember]
        public String hora { get; set; }

        [DataMember]
        public double cantidadPago { get; set; }
    }
}
