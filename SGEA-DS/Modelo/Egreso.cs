using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [DataContract]
    public partial class Egreso
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string concepto { get; set; }

        [DataMember]
        public double monto { get; set; }

        [DataMember]
        public System.DateTime fecha { get; set; }

        [DataMember]
        public Nullable<int> Magistral_Id { get; set; }
    }
}
