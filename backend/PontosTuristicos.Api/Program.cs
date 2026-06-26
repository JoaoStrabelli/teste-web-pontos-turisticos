using Microsoft.EntityFrameworkCore;
using PontosTuristicos.Infrastructure.Data;
using PontosTuristicos.Domain.Repositories;
using PontosTuristicos.Infrastructure.Repositories;
using PontosTuristicos.Application.Interfaces;
using PontosTuristicos.Application.Services;
using PontosTuristicos.Api.Middlewares;

const string CorsPolicyName = "FrontendPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicyName, policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPontoTuristicoRepository, PontoTuristicoRepository>();
builder.Services.AddScoped<IPontoTuristicoService, PontoTuristicoService>();

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(CorsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();