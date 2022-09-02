using Microsoft.EntityFrameworkCore;
using BovinoRemoto.App.Dominio;

namespace BovinoRemoto.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Dueño> Dueños { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDb; Initial Catalog=BovinoRemotoData");
            }
        }
    }
}