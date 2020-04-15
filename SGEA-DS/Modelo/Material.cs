using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [DataContract]
    public partial class Material
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string tipo { get; set; }

        [DataMember]
        public int cantidad { get; set; }

        [DataMember]
        public double costo { get; set; }

        [DataMember]
        public Nullable<int> ActividadId { get; set; }

        [DataMember]
        public int EgresoMaterial_Material_Id { get; set; }
    }
}
