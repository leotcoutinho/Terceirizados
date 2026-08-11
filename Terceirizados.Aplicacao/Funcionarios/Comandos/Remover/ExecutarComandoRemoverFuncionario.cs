using Mediator;
using Terceirizados.Dominio.Repositorios;

namespace Terceirizados.Aplicacao.Funcionarios.Comandos.Remover
{
    public class ExecutarComandoRemoverFuncionario(IRepositorioFuncionario repositorioFuncionario) : ICommandHandler<ComandoRemoverFuncionario>
    {
        public async ValueTask<Unit> Handle(ComandoRemoverFuncionario command, CancellationToken cancellationToken)
        {
            await repositorioFuncionario.Remover(command.funcionarioId);
            return await ValueTask.FromResult(Unit.Value);
        }
    }
}
