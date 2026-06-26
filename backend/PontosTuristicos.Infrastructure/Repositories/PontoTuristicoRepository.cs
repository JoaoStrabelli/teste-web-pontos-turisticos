using Microsoft.EntityFrameworkCore;
using PontosTuristicos.Domain.Entities;
using PontosTuristicos.Domain.Repositories;
using PontosTuristicos.Infrastructure.Data;

namespace PontosTuristicos.Infrastructure.Repositories;

public class PontoTuristicoRepository : IPontoTuristicoRepository
{
    private readonly AppDbContext _context;

    public PontoTuristicoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PontoTuristico> CreateAsync(PontoTuristico pontoTuristico)
    {
        await _context.PontosTuristicos.AddAsync(pontoTuristico);
        await _context.SaveChangesAsync();

        return pontoTuristico;
    }

    public async Task<PontoTuristico?> GetByIdAsync(Guid id)
    {
        return await _context.PontosTuristicos
            .AsNoTracking()
            .FirstOrDefaultAsync(pontoTuristico => pontoTuristico.Id == id);
    }

    public async Task<IReadOnlyList<PontoTuristico>> GetAllAsync(
        string? searchTerm,
        int page,
        int pageSize)
    {
        var query = ApplySearch(_context.PontosTuristicos.AsNoTracking(), searchTerm);

        return await query
            .OrderByDescending(pontoTuristico => pontoTuristico.DataInclusao)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> CountAsync(string? searchTerm)
    {
        var query = ApplySearch(_context.PontosTuristicos.AsNoTracking(), searchTerm);

        return await query.CountAsync();
    }

    private static IQueryable<PontoTuristico> ApplySearch(
        IQueryable<PontoTuristico> query,
        string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return query;

        var normalizedSearchTerm = searchTerm.Trim().ToLower();

        return query.Where(pontoTuristico =>
            pontoTuristico.Nome.ToLower().Contains(normalizedSearchTerm) ||
            pontoTuristico.Descricao.ToLower().Contains(normalizedSearchTerm) ||
            pontoTuristico.Localizacao.ToLower().Contains(normalizedSearchTerm));
    }
}