using PontosTuristicos.Application.DTOs;

namespace PontosTuristicos.Application.Interfaces;

public interface IPontoTuristicoService
{
    Task<PontoTuristicoResponse> CreateAsync(CreatePontoTuristicoRequest request);
    Task<PontoTuristicoResponse?> GetByIdAsync(Guid id);
    Task<PagedResult<PontoTuristicoResponse>> GetAllAsync(string? searchTerm, int page, int pageSize);
}