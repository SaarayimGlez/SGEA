//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Organizador
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Organizador()
    {
        this.Evento = new HashSet<Evento>();
    }

    public int Id { get; set; }
    public string nombre { get; set; }
    public string apellidoPaterno { get; set; }
    public string apellidoMaterno { get; set; }
    public string correoElectronico { get; set; }
    public Nullable<int> idUsuario { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Evento> Evento { get; set; }
    public virtual Usuario Usuario { get; set; }
}
