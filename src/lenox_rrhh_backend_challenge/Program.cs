using lenox_rrhh_backend_challenge.Data;
using lenox_rrhh_backend_challenge.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// InMemoryDatabase. 
builder.Services.AddDbContext<appDbContext>(options =>
    options.UseInMemoryDatabase("appDbContext"));

builder.Services.AddOpenApi();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<appDbContext>();
    dbContext.Database.EnsureCreated(); // Seeding the data.
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lenox RRHH V1");

        c.RoutePrefix = string.Empty;
    });
    app.UseCors("AllowAll");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
