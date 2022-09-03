using Microsoft.EntityFrameworkCore;
using BovinoRemoto.App.Dominio;

namespace BovinoRemoto.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Dueño> Dueños { get; set; }
        public DbSet<Historia_Clinica> HistoriasClinicas { get; set; }
        //public DbSet<Persona> Personas { get; set; }
        public DbSet<Recomendacion> Recomendaciones { get; set; }
        public DbSet<Signo_Vital> SignosVitales { get; set; }
        public DbSet<Vaca> Vacas { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Visita> Visitas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDb; Initial Catalog=BovinoRemotoData");
            }
        }
    }
}