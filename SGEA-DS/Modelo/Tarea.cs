using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelo {
    [DataContract]
    public partial class Tarea {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public String nombre { get; set; }

        [DataMember]
        public String descripcion { get; set; }

        [DataMember]
        public int actividadId { get; set; }
    }
}
