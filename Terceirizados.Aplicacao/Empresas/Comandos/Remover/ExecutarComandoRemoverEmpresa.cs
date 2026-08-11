using Mediator;
using Terceirizados.Dominio.Repositorios;

namespace Terceirizados.Aplicacao.Empresas.Comandos.Remover
{
    public class ExecutarComandoRemoverEmpresa(IRepositorioEmpresa repositorioEmpresa) : ICommandHandler<ComandoRemoverEmpresa>
    {
        public async ValueTask<Unit> Handle(ComandoRemoverEmpresa command, CancellationToken cancellationToken)
        {
            await repositorioEmpresa.Remover(command.empresaId);
            return await ValueTask.FromResult(Unit.Value);
        }
    }
}
