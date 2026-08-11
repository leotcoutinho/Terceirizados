using Mediator;
using Terceirizados.Aplicacao.Dtos;

namespace Terceirizados.Aplicacao.Empresas.Consultas.BuscarPorId
{
    public record ConsultaBuscarPorId(Guid Id) : IQuery<EmpresaDto>;
}
