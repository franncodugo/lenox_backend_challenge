using lenox_rrhh_backend_challenge.DTOs;
using lenox_rrhh_backend_challenge.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace lenox_rrhh_backend_challenge.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class EmpleadosController(IEmpleadoService empleadoService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PagedResponse<EmpleadoListadoDto>>> Get(
        [FromQuery] int empresaId,
        [FromQuery] string? q,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20,
        CancellationToken cancellationToken = default)
    {
        var response = await empleadoService.BuscarEmpleadosAsync(empresaId, q, page, pageSize, cancellationToken);

        return Ok(response);
    }
}
 