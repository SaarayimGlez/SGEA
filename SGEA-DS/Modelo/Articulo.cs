using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [DataContract]
    public partial class Articulo
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string @abstract { get; set; }

        [DataMember]
        public string documento { get; set; }

        [DataMember]
        public string titulo { get; set; }

        [DataMember]
        public string keyword { get; set; }

        [DataMember]
        public bool status { get; set; }
	
	[DataMember]
	public Nullable<int> ActividadId { get; set; }
    }
}
