//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess {
    using System;
    using System.Collections.Generic;

    public partial class Evento {
        public int Id { get; set; }
        public string nombre { get; set; }
        public System.DateTime fechaInicio { get; set; }
        public System.DateTime fechaFin { get; set; }
        public string lugar { get; set; }
        public string institucionOrganizadora { get; set; }

        public override String ToString() {
            return nombre;
        }
    }
}
