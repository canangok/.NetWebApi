using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Mappings;
using WebApi.Entities;

namespace WebApi.DAL.Database
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("defaultConnection")
        {
            var id = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new UserMappings());
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<User> User { get; set; }

    }
}
