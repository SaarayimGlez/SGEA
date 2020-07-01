using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelo {
    [DataContract]
    public partial class Calendario {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public System.DateTime fecha { get; set; }

        [DataMember]
        public TimeSpan horaInicio { get; set; }

        [DataMember]
        public TimeSpan horaFin { get; set; }

        [DataMember]
        public int actividadId { get; set; }
    }
}
