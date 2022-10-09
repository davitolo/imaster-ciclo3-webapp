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
        public DbSet<Historia> Historia {get; set;}
        public DbSet<Mascota> Mascota {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                //.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HuellistacoData1");
                .UseSqlServer(
                    "Data Source = miHuellitasDb.mssql.somee.com; Initial Catalog = miHuellitasDb; user id = davito21_SQLLogin_1; pwd = dtqy4yowo3");
            }
        }
    }
}