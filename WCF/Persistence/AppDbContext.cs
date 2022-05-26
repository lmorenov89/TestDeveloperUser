using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WCF.Models;

namespace WCF.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext() : base("name=DefaultConnection")
        {

        }

        //Disabled cascade Delete
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}