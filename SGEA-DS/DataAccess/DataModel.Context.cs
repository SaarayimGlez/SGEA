﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DataModelContainer : DbContext
    {
        public DataModelContainer()
            : base("name=DataModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Actividad> ActividadSet { get; set; }
        public virtual DbSet<Articulo> ArticuloSet { get; set; }
        public virtual DbSet<RegistroArticulo> RegistroArticuloSet { get; set; }
        public virtual DbSet<Adscripcion> AdscripcionSet { get; set; }
        public virtual DbSet<Autor> AutorSet { get; set; }
        public virtual DbSet<Calendario> CalendarioSet { get; set; }
        public virtual DbSet<Magistral> MagistralSet { get; set; }
        public virtual DbSet<Participante> ParticipanteSet { get; set; }
        public virtual DbSet<Ingreso> IngresoSet { get; set; }
        public virtual DbSet<Presupuesto> PresupuestoSet { get; set; }
        public virtual DbSet<Comite> ComiteSet { get; set; }
        public virtual DbSet<Asistente> AsistenteSet { get; set; }
        public virtual DbSet<Tarea> TareaSet { get; set; }
        public virtual DbSet<Patrocinador> PatrocinadorSet { get; set; }
        public virtual DbSet<Egreso> EgresoSet { get; set; }
        public virtual DbSet<Material> MaterialSet { get; set; }
        public virtual DbSet<Evaluacion> EvaluacionSet { get; set; }
        public virtual DbSet<Evento> EventoSet { get; set; }
        public virtual DbSet<MiembroComite> MiembroComiteSet { get; set; }
        public virtual DbSet<Organizador> OrganizadorSet { get; set; }
        public virtual DbSet<Usuario> UsuarioSet { get; set; }
        public virtual DbSet<AutorArticulo> AutorArticuloSet { get; set; }
    }
}
