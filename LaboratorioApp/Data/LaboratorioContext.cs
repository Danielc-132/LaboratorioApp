using System.Data.Entity;
using LaboratorioApp.Models;

namespace LaboratorioApp.Data
{
    public class LaboratorioContext : DbContext
    {
        public LaboratorioContext() : base("name=LaboratorioContext")
        {
            Database.SetInitializer<LaboratorioContext>(null);
            this.Database.Log = query => System.Diagnostics.Debug.WriteLine(query);
        }

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
    }
}