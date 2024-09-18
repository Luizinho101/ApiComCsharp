using Microsoft.EntityFrameworkCore;
using ApiCsharp.Models;

namespace ApiCsharp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Contribuinte> Contribuintes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais, se necessário
        }
    }
}
