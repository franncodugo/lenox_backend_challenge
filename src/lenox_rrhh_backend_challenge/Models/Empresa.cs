namespace lenox_rrhh_backend_challenge.Models;

public sealed class Empresa
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;

    public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
