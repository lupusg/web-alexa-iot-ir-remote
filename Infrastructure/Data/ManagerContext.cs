using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ManagerContext : DbContext
    {
        public ManagerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Signal> Signals { get; set; }

        protected void onModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        internal Task saveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}