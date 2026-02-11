using lenox_rrhh_backend_challenge.DTOs;

namespace lenox_rrhh_backend_challenge.Services;

public interface IEmpleadoService
{
    Task<PagedResponse<EmpleadoListadoDto>> BuscarEmpleadosAsync(
        int empresaId,
        string? query,
        int page,
        int pageSize,
        CancellationToken cancellationToken);
}
