using lenox_rrhh_backend_challenge.Data;
using lenox_rrhh_backend_challenge.DTOs;
using Microsoft.EntityFrameworkCore;

namespace lenox_rrhh_backend_challenge.Services;

public sealed class EmpleadoService : IEmpleadoService
{
    private readonly appDbContext context;

    public EmpleadoService(appDbContext context)
        => this.context = context;

    public async Task<PagedResponse<EmpleadoListadoDto>> BuscarEmpleadosAsync(
        int empresaId, 
        string? q,
        int page, 
        int pageSize, 
        CancellationToken cancellationToken)
    {
        var query = context.Empleados.AsNoTracking()
            .Where(e => e.EmpresaId == empresaId && e.Activo);

        if (!string.IsNullOrWhiteSpace(q))
        {
            var search = q.Trim();
            query = query.Where(e => e.Nombre.Contains(search) ||
                                     e.Email.Contains(search));
        }

        var total = await query.CountAsync(cancellationToken);

        if (total == 0) 
        {
            return new PagedResponse<EmpleadoListadoDto>
            {
                Page = page,
                PageSize = pageSize,
                Total = 0,
                Items = []
            };
        }

        var items = await query
            .OrderBy(e => e.Nombre)
            .ThenBy(e => e.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(e => new EmpleadoListadoDto(
                e.Id,
                e.Nombre,
                e.Email,
                e.Empresa.Nombre,
                e.Movimientos
                    .OrderByDescending(m => m.Fecha)
                    .Select(m => (DateTime?)m.Fecha)
                    .FirstOrDefault()
            ))
            .ToListAsync(cancellationToken); 

        return new PagedResponse<EmpleadoListadoDto>
        {
            Page = page,
            PageSize = pageSize,
            Total = total,
            Items = items
        };
    }
}
