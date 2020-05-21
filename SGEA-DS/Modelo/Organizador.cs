using System;
using System.Runtime.Serialization;

namespace Modelo
{
    [DataContract]
    public class Organizador
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
        public Nullable<int> idUsuario { get; set; }
    }
}