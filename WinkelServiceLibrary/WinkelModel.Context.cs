﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinkelServiceLibrary
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WinkelModel : DbContext
    {
        public WinkelModel()
            : base("name=WinkelModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AankoopRegels> AankoopRegels { get; set; }
        public virtual DbSet<Aankopen> Aankopen { get; set; }
        public virtual DbSet<Gebruikers> Gebruikers { get; set; }
        public virtual DbSet<Producten> Producten { get; set; }
    }
}