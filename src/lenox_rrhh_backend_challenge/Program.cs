using lenox_rrhh_backend_challenge.Data;
using lenox_rrhh_backend_challenge.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// InMemoryDatabase. 
builder.Services.AddDbContext<appDbContext>(options =>
    options.UseInMemoryDatabase("LenoxDb"));

builder.Services.AddOpenApi();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<appDbContext>();
    dbContext.Database.EnsureCreated(); // Seeding the data.
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
