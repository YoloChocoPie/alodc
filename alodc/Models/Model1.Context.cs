﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace alodc.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QUANLYCANTEENEntities : DbContext
    {
        public QUANLYCANTEENEntities()
            : base("name=QUANLYCANTEENEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<CONTACT> CONTACTs { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<FACULTY> FACULTies { get; set; }
        public virtual DbSet<FOOD> FOODs { get; set; }
        public virtual DbSet<INTRODUCTION> INTRODUCTIONs { get; set; }
        public virtual DbSet<MENU> MENUs { get; set; }
        public virtual DbSet<NOTIFICATION> NOTIFICATIONs { get; set; }
        public virtual DbSet<ORDER> ORDERs { get; set; }
        public virtual DbSet<ORDER_DETAIL> ORDER_DETAIL { get; set; }
        public virtual DbSet<SLIDER> SLIDERs { get; set; }

       
    }
}
