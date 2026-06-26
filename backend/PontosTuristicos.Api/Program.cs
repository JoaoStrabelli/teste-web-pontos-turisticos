using Microsoft.EntityFrameworkCore;
using PontosTuristicos.Infrastructure.Data;
using PontosTuristicos.Domain.Repositories;
using PontosTuristicos.Infrastructure.Repositories;
using PontosTuristicos.Application.Interfaces;
using PontosTuristicos.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPontoTuristicoRepository, PontoTuristicoRepository>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();