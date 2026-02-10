namespace lenox_rrhh_backend_challenge.DTOs;

public record EmpleadoListadoDto(
    int Id,
    string Nombre,
    string Email,
    string nombreEmpresa,
    DateTime? UltMovimientoFecha
);

