﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DevFolio.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DbDevFolioEntities : DbContext
    {
        public DbDevFolioEntities()
            : base("name=DbDevFolioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TblAbout> TblAbout { get; set; }
        public virtual DbSet<TblAddress> TblAddress { get; set; }
        public virtual DbSet<TblAdmin> TblAdmin { get; set; }
        public virtual DbSet<TblCategory> TblCategory { get; set; }
        public virtual DbSet<TblContact> TblContact { get; set; }
        public virtual DbSet<TblFeature> TblFeature { get; set; }
        public virtual DbSet<TblProfile> TblProfile { get; set; }
        public virtual DbSet<TblProject> TblProject { get; set; }
        public virtual DbSet<TblService> TblService { get; set; }
        public virtual DbSet<TblSkill> TblSkill { get; set; }
        public virtual DbSet<TblSocialMedia> TblSocialMedia { get; set; }
        public virtual DbSet<TblTestimonial> TblTestimonial { get; set; }
    
        public virtual ObjectResult<Nullable<int>> GetLastSkillTitle()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetLastSkillTitle");
        }
    
        public virtual ObjectResult<string> LastSkillTitle()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("LastSkillTitle");
        }
    
        public virtual ObjectResult<string> MostUsedProjectCategory()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("MostUsedProjectCategory");
        }
    
        public virtual ObjectResult<string> LastAddedSocialMedia()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("LastAddedSocialMedia");
        }
    }
}
