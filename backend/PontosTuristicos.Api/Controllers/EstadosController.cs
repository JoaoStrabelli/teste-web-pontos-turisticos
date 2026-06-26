using Microsoft.AspNetCore.Mvc;

namespace PontosTuristicos.Api.Controllers;

[ApiController]
[Route("api/estados")]
public class EstadosController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<EstadoResponse>> GetAll()
    {
        var estados = new List<EstadoResponse>
        {
            new("AC", "Acre"),
            new("AL", "Alagoas"),
            new("AP", "Amapá"),
            new("AM", "Amazonas"),
            new("BA", "Bahia"),
            new("CE", "Ceará"),
            new("DF", "Distrito Federal"),
            new("ES", "Espírito Santo"),
            new("GO", "Goiás"),
            new("MA", "Maranhão"),
            new("MT", "Mato Grosso"),
            new("MS", "Mato Grosso do Sul"),
            new("MG", "Minas Gerais"),
            new("PA", "Pará"),
            new("PB", "Paraíba"),
            new("PR", "Paraná"),
            new("PE", "Pernambuco"),
            new("PI", "Piauí"),
            new("RJ", "Rio de Janeiro"),
            new("RN", "Rio Grande do Norte"),
            new("RS", "Rio Grande do Sul"),
            new("RO", "Rondônia"),
            new("RR", "Roraima"),
            new("SC", "Santa Catarina"),
            new("SP", "São Paulo"),
            new("SE", "Sergipe"),
            new("TO", "Tocantins")
        };

        return Ok(estados);
    }
}

public record EstadoResponse(string Sigla, string Nome);