using Microsoft.EntityFrameworkCore;
using DeskFlowApi.Models.Entities;

namespace DeskFlowApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categorias>();
        }
    }
}