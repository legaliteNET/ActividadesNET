﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace legaliteNET.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class legaliteEntities : DbContext
    {
        public legaliteEntities()
            : base("name=legaliteEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<actividade> actividades { get; set; }
        public virtual DbSet<asesore> asesores { get; set; }
        public virtual DbSet<cliente> clientes { get; set; }
        public virtual DbSet<detallesolicitud> detallesolicituds { get; set; }
        public virtual DbSet<solicitude> solicitudes { get; set; }
    }
}
