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

public partial class Ingreso
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Ingreso()
    {
        this.PatrocinadorSet = new HashSet<Patrocinador>();
    }

    public int Id { get; set; }
    public string concepto { get; set; }
    public double monto { get; set; }
    public System.DateTime fecha { get; set; }

    public virtual RegistroArticulo RegistroArticulo { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Patrocinador> PatrocinadorSet { get; set; }
}
