using CreateOne.Models;
using Microsoft.EntityFrameworkCore;

namespace CreateOne.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                   new Category { Id = 1, Name = "Action", DisplayOrder = 4 },
                   new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                   new Category { Id = 3, Name = "History", DisplayOrder = 8 }
                );
        }
    }
}
