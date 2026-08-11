using Mediator;

namespace Terceirizados.Aplicacao.Funcionarios.Comandos.Remover
{
    public record ComandoRemoverFuncionario(Guid funcionarioId) : ICommand;
}
