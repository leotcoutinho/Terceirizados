using Mediator;

namespace Terceirizados.Aplicacao.Funcionarios.Comandos.Cadastrar
{
    public record ComandoCadastrarFuncionario(string Nome, string Cpf, DateTime DataNascimento, string Email, string Telefone, Guid EmpresaId, Guid CargoId) : ICommand<Guid>;
    
}
