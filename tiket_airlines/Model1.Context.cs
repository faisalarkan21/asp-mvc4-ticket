﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tiket_airlines
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class tiket_airlinesEntitiesMVC : DbContext
    {
        public tiket_airlinesEntitiesMVC()
            : base("name=tiket_airlinesEntitiesMVC")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<admin> admin { get; set; }
        public virtual DbSet<detil_pesan_tiket> detil_pesan_tiket { get; set; }
        public virtual DbSet<pajak_bandara> pajak_bandara { get; set; }
        public virtual DbSet<pembeli> pembeli { get; set; }
        public virtual DbSet<pembeli_validasi> pembeli_validasi { get; set; }
        public virtual DbSet<tgl_pesan> tgl_pesan { get; set; }
    }
}
