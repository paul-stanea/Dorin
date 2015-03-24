using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
//using DisertatieV1.Models;
using System.Data.Entity.Validation;
using Disertatie3.Models;

namespace Disertatie3.Models
{
    public class DbEntities: DbContext 
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Consum> Consum { get; set; }
        public DbSet<MateriiPrime> MateriiPrime { get; set; }
        public DbSet<Produse> Produse { get; set; }
        public DbSet<Retete> Retete { get; set; }
        public DbSet<StocMaterii> StocMaterii { get; set; }
        public DbSet<StocProduse> StocProduse { get; set; }
        public DbSet<Plati> Plati { get; set; }
        public DbSet<Incasari> Incasari { get; set; }


        public DbEntities()
            : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}