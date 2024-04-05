using Games.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Games.DAL.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Category> Categories { get; set; }
     
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
