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

        public DbSet<SignalProtocol> SignalProtocols { get; set; }

        protected void onModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}