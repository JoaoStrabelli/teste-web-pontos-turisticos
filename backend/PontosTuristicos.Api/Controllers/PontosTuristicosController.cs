using Microsoft.AspNetCore.Mvc;
using PontosTuristicos.Application.DTOs;
using PontosTuristicos.Application.Interfaces;

namespace PontosTuristicos.Api.Controllers;

[ApiController]
[Route("api/pontos-turisticos")]
public class PontosTuristicosController : ControllerBase
{
    private readonly IPontoTuristicoService _pontoTuristicoService;

    public PontosTuristicosController(IPontoTuristicoService pontoTuristicoService)
    {
        _pontoTuristicoService = pontoTuristicoService;
    }

    [HttpPost]
    public async Task<ActionResult<PontoTuristicoResponse>> Create(
        [FromBody] CreatePontoTuristicoRequest request)
    {
        var pontoTuristico = await _pontoTuristicoService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = pontoTuristico.Id },
            pontoTuristico);
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<PontoTuristicoResponse>>> GetAll(
        [FromQuery] string? searchTerm,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 5)
    {
        var result = await _pontoTuristicoService.GetAllAsync(searchTerm, page, pageSize);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PontoTuristicoResponse>> GetById(Guid id)
    {
        var pontoTuristico = await _pontoTuristicoService.GetByIdAsync(id);

        if (pontoTuristico is null)
            return NotFound(new { message = "Ponto turístico não encontrado." });

        return Ok(pontoTuristico);
    }
}