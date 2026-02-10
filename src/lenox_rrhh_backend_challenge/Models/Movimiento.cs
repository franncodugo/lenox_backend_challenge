namespace lenox_rrhh_backend_challenge.Models;

public sealed class Movimiento
{
    public int Id { get; set; }
    public int EmpleadoId { get; set; }
    public DateTime Fecha { get; set; }
    public string Tipo { get; set; } = null!;

    public Empleado Empleado { get; set; } = null!;
}
