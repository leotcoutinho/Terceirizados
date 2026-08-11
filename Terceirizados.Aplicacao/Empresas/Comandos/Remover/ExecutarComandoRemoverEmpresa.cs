using Mediator;
using Terceirizados.Dominio.Repositorios;

namespace Terceirizados.Aplicacao.Empresas.Comandos.Remover
{
    public class ExecutarComandoRemoverEmpresa(IRepositorioEmpresa repositorioEmpresa) : ICommandHandler<ComandoRemoverEmpresa>
    {
        public async ValueTask<Unit> Handle(ComandoRemoverEmpresa command, CancellationToken cancellationToken)
        {
            var empresa = await repositorioEmpresa.BuscarPorId(command.empresaId, cancellationToken);

            if (empresa == null)
                throw new Exception("Empresa não encontrada.");

            await repositorioEmpresa.Remover(empresa);

            return await ValueTask.FromResult(Unit.Value);
        }
    }
}
