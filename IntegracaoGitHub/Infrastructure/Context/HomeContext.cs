using IntegracaoGitHub.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntegracaoGitHub.Infrastructure.Context
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Favorite> Favorites { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Favorite>()
                .HasKey(m => m.Id);
            base.OnModelCreating(builder);
            
        }
    }
}
