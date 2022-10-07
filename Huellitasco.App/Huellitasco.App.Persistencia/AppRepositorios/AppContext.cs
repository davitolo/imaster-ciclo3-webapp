using Microsoft.EntityFrameworkCore;
using Huellitasco.App.Dominio;
namespace Huellitasco.App.Persistencia
{
    public class AppContext:DbContext
    {
        public DbSet<Persona> Personas {get; set;}
        public DbSet<Veterinario> Veterinario {get; set;}
        public DbSet<Dueno> Dueno {get; set;}
        public DbSet<VisitasPyP> VisitasPyP {get; set;}
        public DbSet<Historia> Historias {get; set;}
        public DbSet<Mascota> Mascota {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HuellistacoData");
                //
            }
        }
    }
}