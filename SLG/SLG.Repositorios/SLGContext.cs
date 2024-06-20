using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using SLG.Aplicacion;

namespace SLG.Repositorios;

public class SLGContext : DbContext{
    public DbSet<Expediente> Expedientes { get; set; }
    public DbSet<Tramite> Tramites { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=SLG.sqlite");
    }
}