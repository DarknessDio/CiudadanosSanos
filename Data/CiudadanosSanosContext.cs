using CiudadanosSanos.Models;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Data
{
    public class CiudadanosSanosContext : DbContext
    {
        public CiudadanosSanosContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Paciente> Paciente { get; set;}
        public DbSet<Consulta> Consulta { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=CiudadanosSanosDB; Trusted_Connection= True;");
        }
    }
}
