using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [DataContract]
    public partial class Evento
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public System.DateTime fechaInicio { get; set; }

        [DataMember]
        public System.DateTime fechaFin { get; set; }

        [DataMember]
        public string lugar { get; set; }

        [DataMember]
        public string institucionOrganizadora { get; set; }

        [DataMember]
        public Nullable<int> EventoPresupuesto_Evento_Id { get; set; }
    }
}
