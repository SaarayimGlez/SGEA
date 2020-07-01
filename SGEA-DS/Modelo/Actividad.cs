using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelo {
    [DataContract]
    public partial class Actividad {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public String nombre { get; set; }

        [DataMember]
        public double costo { get; set; }

        [DataMember]
        public String aula { get; set; }

        [DataMember]
        public String tipo { get; set; }

        [DataMember]
        public int eventoId { get; set; }

        [DataMember]
        public int magistralId { get; set; }

        [DataMember]
        public int participanteId { get; set; }

        [DataMember]
        public int articuloId { get; set; }

    }
}
