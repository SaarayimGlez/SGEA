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

public partial class Evaluacion
{
    public int Id { get; set; }
    public int calificacion { get; set; }
    public string descripcion { get; set; }
    public System.DateTime fecha { get; set; }
    public int ArticuloId { get; set; }
    public int MiembroComite_Id { get; set; }

    public virtual Articulo Articulo { get; set; }
    public virtual MiembroComite MiembroComite { get; set; }
}
