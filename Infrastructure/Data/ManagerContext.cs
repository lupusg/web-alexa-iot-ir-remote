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
    }
}