namespace PontosTuristicos.Domain.Entities;

public class PontoTuristico
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Descricao { get; private set; } = string.Empty;
    public string Localizacao { get; private set; } = string.Empty;
    public string Cidade { get; private set; } = string.Empty;
    public string Estado { get; private set; } = string.Empty;
    public DateTime DataInclusao { get; private set; }

    private PontoTuristico()
    {
    }

    public PontoTuristico(
        string nome,
        string descricao,
        string localizacao,
        string cidade,
        string estado)
    {
        Validar(nome, descricao, localizacao, cidade, estado);

        Id = Guid.NewGuid();
        Nome = nome.Trim();
        Descricao = descricao.Trim();
        Localizacao = localizacao.Trim();
        Cidade = cidade.Trim();
        Estado = estado.Trim().ToUpper();
        DataInclusao = DateTime.UtcNow;
    }

    public void Atualizar(
        string nome,
        string descricao,
        string localizacao,
        string cidade,
        string estado)
    {
        Validar(nome, descricao, localizacao, cidade, estado);

        Nome = nome.Trim();
        Descricao = descricao.Trim();
        Localizacao = localizacao.Trim();
        Cidade = cidade.Trim();
        Estado = estado.Trim().ToUpper();
    }

    private static void Validar(
        string nome,
        string descricao,
        string localizacao,
        string cidade,
        string estado)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do ponto turístico é obrigatório.");

        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentException("A descrição do ponto turístico é obrigatória.");

        if (descricao.Trim().Length > 100)
            throw new ArgumentException("A descrição deve ter no máximo 100 caracteres.");

        if (string.IsNullOrWhiteSpace(localizacao))
            throw new ArgumentException("A localização do ponto turístico é obrigatória.");

        if (string.IsNullOrWhiteSpace(cidade))
            throw new ArgumentException("A cidade do ponto turístico é obrigatória.");

        if (string.IsNullOrWhiteSpace(estado))
            throw new ArgumentException("O estado do ponto turístico é obrigatório.");

        if (estado.Trim().Length != 2)
            throw new ArgumentException("O estado deve ser informado no formato UF, com 2 caracteres.");
    }
}