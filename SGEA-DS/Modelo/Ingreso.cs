using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelo {
    [DataContract]
    public partial class Ingreso {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public String concepto { get; set; }

        [DataMember]
        public double monto { get; set; }

        [DataMember]
        public System.DateTime fecha { get; set; }

        [DataMember]
        public Nullable<int> RegistroIngresoArticulo_id { get; set; }

        [DataMember]
        public Nullable<int> Patrocinador_id { get; set; }
    }
}
