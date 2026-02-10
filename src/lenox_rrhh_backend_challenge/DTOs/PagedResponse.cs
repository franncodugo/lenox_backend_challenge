namespace lenox_rrhh_backend_challenge.DTOs;

public sealed class PagedResponse<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }
    public IEnumerable<T> Items { get; set; } = null!;
}
