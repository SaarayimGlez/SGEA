using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [DataContract]
    public partial class Comite
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string descripcion { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public int EventoId { get; set; }
    }
}
