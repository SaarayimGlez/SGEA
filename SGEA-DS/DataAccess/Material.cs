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

public partial class Material
{
    public int Id { get; set; }
    public string tipo { get; set; }
    public int cantidad { get; set; }
    public double costo { get; set; }
    public Nullable<int> ActividadId { get; set; }
    public int EgresoMaterial_Material_Id { get; set; }

    public virtual Actividad ActividadSet { get; set; }
    public virtual Egreso EgresoSet { get; set; }
}
