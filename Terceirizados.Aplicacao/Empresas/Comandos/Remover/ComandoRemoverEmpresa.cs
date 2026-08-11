using Mediator;

namespace Terceirizados.Aplicacao.Empresas.Comandos.Remover
{
    public record ComandoRemoverEmpresa(Guid empresaId) : ICommand;
}
