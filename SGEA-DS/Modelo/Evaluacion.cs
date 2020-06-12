using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [DataContract]
    public partial class Evaluacion
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int calificacion { get; set; }

        [DataMember]
        public string descripcion { get; set; }

        [DataMember]
        public System.DateTime fecha { get; set; }

        [DataMember]
        public int ArticuloId { get; set; }

        [DataMember]
        public int MiembroComite_Id { get; set; }
    }
}
