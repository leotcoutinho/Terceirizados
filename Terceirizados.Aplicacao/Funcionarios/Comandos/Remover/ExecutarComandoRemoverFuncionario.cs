using Mediator;
using Terceirizados.Dominio.Repositorios;

namespace Terceirizados.Aplicacao.Funcionarios.Comandos.Remover
{
    public class ExecutarComandoRemoverFuncionario(IRepositorioFuncionario repositorioFuncionario) : ICommandHandler<ComandoRemoverFuncionario>
    {
        public async ValueTask<Unit> Handle(ComandoRemoverFuncionario command, CancellationToken cancellationToken)
        {
            var funcionario = await repositorioFuncionario.BuscarPorId(command.funcionarioId);

            if(funcionario == null)
                throw new Exception($"Funcionário com ID {command.funcionarioId} não encontrado.");

            await repositorioFuncionario.Remover(funcionario);

            return await ValueTask.FromResult(Unit.Value);
        }
    }
}
