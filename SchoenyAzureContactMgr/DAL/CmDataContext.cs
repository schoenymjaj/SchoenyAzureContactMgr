using SchoenyAzureContactMgr.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System;

using System.Collections.Generic;
using System.Data;

namespace SchoenyAzureContactMgr.DAL
{

    public class CmDataContext : DbContext
    {
        public DbSet<GameType> GameType { get; set; }

        static CmDataContext()
        {
            Database.SetInitializer(new InitializeCmDatabaseWithSeedData());
        }

        public CmDataContext()
            : base(System.Configuration.ConfigurationManager.ConnectionStrings["SchoenyAzureContactMgr.Models.CmDataContext"].ConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public override int SaveChanges()
        {
            return SaveChangesLocal(null);
        }

        public int SaveChanges(string windowsIdentityName)
        {
            return SaveChangesLocal(windowsIdentityName);
        }

        private int SaveChangesLocal(string windowsIdentityName)
        {

            foreach (var entity in ChangeTracker.Entries().
                Where(p => p.State == EntityState.Added || p.State == EntityState.Modified))
            {
                if (entity.State == EntityState.Added && entity.Entity is IDateCreated)
                {
                    ((IDateCreated)entity.Entity).DateCreated = DateTime.Now;
                    ((ICreatedBy)entity.Entity).CreatedBy = windowsIdentityName;
                }
                if (entity.State == EntityState.Modified && entity.Entity is IDateUpdated)
                {
                    ((IDateCreated)entity.Entity).DateCreated = entity.GetDatabaseValues().GetValue<DateTime>("DateCreated");
                    ((ICreatedBy)entity.Entity).CreatedBy = entity.GetDatabaseValues().GetValue<string>("CreatedBy");
                    ((IDateUpdated)entity.Entity).DateUpdated = DateTime.Now;
                    ((IUpdatedBy)entity.Entity).UpdatedBy = windowsIdentityName;
                }
            }

            return base.SaveChanges();

        }

    }


}