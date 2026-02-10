namespace lenox_rrhh_backend_challenge.Models;

public sealed class Empleado
{
    public int Id { get; set; }
    public int EmpresaId { get; set; }
    public string Nombre { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool Activo { get; set; }

    public Empresa Empresa { get; set; } = null!;
    public ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
