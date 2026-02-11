using lenox_rrhh_backend_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace lenox_rrhh_backend_challenge.Data;

public sealed class appDbContext(DbContextOptions<appDbContext> options) : DbContext(options)
{
    public DbSet<Empresa> Empresas => Set<Empresa>();
    public DbSet<Empleado> Empleados => Set<Empleado>();
    public DbSet<Movimiento> Movimientos => Set<Movimiento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data.
        modelBuilder.Entity<Empresa>().HasData(
            new Empresa { Id = 1, Nombre = "Lenox Corp" },
            new Empresa { Id = 2, Nombre = "Tech Solutions" }
        );

        modelBuilder.Entity<Empleado>().HasData(
            new Empleado { Id = 1, EmpresaId = 1, Nombre = "Ana Lopez", Email = "ana.lopez@lenox.com", Activo = true },
            new Empleado { Id = 2, EmpresaId = 1, Nombre = "Carlos Perez", Email = "carlos.perez@lenox.com", Activo = true },
            new Empleado { Id = 3, EmpresaId = 1, Nombre = "Ana Maria Gomez", Email = "anamaria@lenox.com", Activo = true },
            new Empleado { Id = 4, EmpresaId = 2, Nombre = "Juan Tech", Email = "juan@tech.com", Activo = true } 
        );

        modelBuilder.Entity<Movimiento>().HasData(
            new Movimiento { Id = 1, EmpleadoId = 1, Fecha = DateTime.UtcNow.AddMonths(-6), Tipo = "Contratación" },
            new Movimiento { Id = 2, EmpleadoId = 1, Fecha = DateTime.UtcNow.AddMonths(-1), Tipo = "Ascenso" },
            new Movimiento { Id = 3, EmpleadoId = 2, Fecha = DateTime.UtcNow.AddMonths(-3), Tipo = "Contratación" }
        );
    }
}
