using PontosTuristicos.Domain.Entities;

namespace PontosTuristicos.Domain.Repositories;

public interface IPontoTuristicoRepository
{
    Task<PontoTuristico> CreateAsync(PontoTuristico pontoTuristico);
    Task<PontoTuristico?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<PontoTuristico>> GetAllAsync(string? searchTerm, int page, int pageSize);
    Task<int> CountAsync(string? searchTerm);
}