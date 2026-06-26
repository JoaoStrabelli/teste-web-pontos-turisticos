using PontosTuristicos.Application.DTOs;
using PontosTuristicos.Application.Interfaces;
using PontosTuristicos.Domain.Entities;
using PontosTuristicos.Domain.Repositories;

namespace PontosTuristicos.Application.Services;

public class PontoTuristicoService : IPontoTuristicoService
{
    private const int DefaultPage = 1;
    private const int DefaultPageSize = 5;
    private const int MaxPageSize = 20;

    private readonly IPontoTuristicoRepository _pontoTuristicoRepository;

    public PontoTuristicoService(IPontoTuristicoRepository pontoTuristicoRepository)
    {
        _pontoTuristicoRepository = pontoTuristicoRepository;
    }

    public async Task<PontoTuristicoResponse> CreateAsync(CreatePontoTuristicoRequest request)
    {
        var pontoTuristico = new PontoTuristico(
            request.Nome,
            request.Descricao,
            request.Localizacao,
            request.Cidade,
            request.Estado);

        var createdPontoTuristico = await _pontoTuristicoRepository.CreateAsync(pontoTuristico);

        return MapToResponse(createdPontoTuristico);
    }

    public async Task<PontoTuristicoResponse?> GetByIdAsync(Guid id)
    {
        var pontoTuristico = await _pontoTuristicoRepository.GetByIdAsync(id);

        if (pontoTuristico is null)
            return null;

        return MapToResponse(pontoTuristico);
    }

    public async Task<PagedResult<PontoTuristicoResponse>> GetAllAsync(
        string? searchTerm,
        int page,
        int pageSize)
    {
        page = page <= 0 ? DefaultPage : page;
        pageSize = pageSize <= 0 ? DefaultPageSize : pageSize;
        pageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;

        var totalItems = await _pontoTuristicoRepository.CountAsync(searchTerm);
        var pontosTuristicos = await _pontoTuristicoRepository.GetAllAsync(searchTerm, page, pageSize);

        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        return new PagedResult<PontoTuristicoResponse>
        {
            Items = pontosTuristicos.Select(MapToResponse).ToList(),
            Page = page,
            PageSize = pageSize,
            TotalItems = totalItems,
            TotalPages = totalPages
        };
    }

    private static PontoTuristicoResponse MapToResponse(PontoTuristico pontoTuristico)
    {
        return new PontoTuristicoResponse
        {
            Id = pontoTuristico.Id,
            Nome = pontoTuristico.Nome,
            Descricao = pontoTuristico.Descricao,
            Localizacao = pontoTuristico.Localizacao,
            Cidade = pontoTuristico.Cidade,
            Estado = pontoTuristico.Estado,
            DataInclusao = pontoTuristico.DataInclusao
        };
    }
}