using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Modelo
{
    [DataContract]
    public partial class Patrocinador
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string apellidoPaterno { get; set; }

        [DataMember]
        public string apellidoMaterno { get; set; }

        [DataMember]
        public string correoElectronico { get; set; }

        [DataMember]
        public string empresa { get; set; }

        [DataMember]
        public string direccion { get; set; }

        [DataMember]
        public string numeroTelefono { get; set; }

        [DataMember]
        public Nullable<int> IngresoPatrocinador_Patrocinador_Id { get; set; }
    }
}
