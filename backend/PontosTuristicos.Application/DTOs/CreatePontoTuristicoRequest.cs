using System.ComponentModel.DataAnnotations;

namespace PontosTuristicos.Application.DTOs;

public class CreatePontoTuristicoRequest
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [MaxLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "A localização é obrigatória.")]
    [MaxLength(200, ErrorMessage = "A localização deve ter no máximo 200 caracteres.")]
    public string Localizacao { get; set; } = string.Empty;

    [Required(ErrorMessage = "A cidade é obrigatória.")]
    [MaxLength(100, ErrorMessage = "A cidade deve ter no máximo 100 caracteres.")]
    public string Cidade { get; set; } = string.Empty;

    [Required(ErrorMessage = "O estado é obrigatório.")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "O estado deve conter exatamente 2 caracteres.")]
    public string Estado { get; set; } = string.Empty;
}