namespace Terceirizados.Aplicacao.Dtos
{
    public record EmpresaFuncionariosDto(Guid EmpresaId, string Nome, string Cnpj, IEnumerable<FuncionarioDto> Funcionarios);
}
