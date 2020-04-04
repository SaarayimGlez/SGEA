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

public partial class Actividad
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Actividad()
    {
        this.Participante = new HashSet<Participante>();
        this.Material = new HashSet<Material>();
    }

    public int Id { get; set; }
    public string nombre { get; set; }
    public double costo { get; set; }
    public string aula { get; set; }
    public string tipo { get; set; }
    public int EventoId { get; set; }
    public int ComiteId { get; set; }

    public virtual Articulo Articulo { get; set; }
    public virtual Magistral Magistral { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Participante> Participante { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Material> Material { get; set; }
    public virtual Comite Comite { get; set; }
    public virtual Evento EventoSet { get; set; }

    public override String ToString()
    {
        return nombre;
    }
}
