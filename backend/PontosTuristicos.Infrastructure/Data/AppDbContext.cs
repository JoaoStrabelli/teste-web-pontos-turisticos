using Microsoft.EntityFrameworkCore;
using PontosTuristicos.Domain.Entities;

namespace PontosTuristicos.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<PontoTuristico> PontosTuristicos => Set<PontoTuristico>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PontoTuristico>(entity =>
        {
            entity.ToTable("PontosTuristicos");

            entity.HasKey(pontoTuristico => pontoTuristico.Id);

            entity.Property(pontoTuristico => pontoTuristico.Nome)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(pontoTuristico => pontoTuristico.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(pontoTuristico => pontoTuristico.Localizacao)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(pontoTuristico => pontoTuristico.Cidade)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(pontoTuristico => pontoTuristico.Estado)
                .IsRequired()
                .HasMaxLength(2);

            entity.Property(pontoTuristico => pontoTuristico.DataInclusao)
                .IsRequired();
        });
    }
}