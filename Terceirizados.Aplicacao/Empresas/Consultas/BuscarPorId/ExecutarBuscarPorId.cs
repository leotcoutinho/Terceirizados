using Mediator;
using Terceirizados.Aplicacao.Dtos;
using Terceirizados.Dominio.Entidades;
using Terceirizados.Dominio.Repositorios;

namespace Terceirizados.Aplicacao.Empresas.Consultas.BuscarPorId
{
    public class ExecutarBuscarPorId(IRepositorioEmpresa repositorioEmpresa) : IQueryHandler<ConsultaBuscarPorId, EmpresaDto?>
    {
        public async ValueTask<EmpresaDto?> Handle(ConsultaBuscarPorId request, CancellationToken cancellationToken)
        {
            Empresa? empresa = await repositorioEmpresa.BuscarPorId(request.Id, cancellationToken);

            if (empresa is null)
                return null;

            return new EmpresaDto(
                empresa.EmpresaId,      
                empresa.RazaoSocial,
                empresa.Cnpj
            );
        }
    }
}
