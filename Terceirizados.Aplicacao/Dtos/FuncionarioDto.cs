namespace Terceirizados.Aplicacao.Dtos
{
    public record FuncionarioDto(Guid FuncionarioId,string Nome, string Cpf, DateTime DataNascimento, string Email, string? Telefone, Guid EmpresaId, Guid CargoId);
}
