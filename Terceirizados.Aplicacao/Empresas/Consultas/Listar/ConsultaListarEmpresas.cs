using Mediator;
using Terceirizados.Aplicacao.Dtos;

namespace Terceirizados.Aplicacao.Empresas.Consultas.Listar
{
    public record ConsultaListarEmpresas : IQuery<ICollection<EmpresaDto>>;    
}
