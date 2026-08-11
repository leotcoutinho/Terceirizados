using Mediator;
using Terceirizados.Aplicacao.Dtos;

namespace Terceirizados.Aplicacao.Empresas.Consultas.BuscarEmpresaComFuncionarios
{
    public record ConsultaBuscarEmpresaComFuncionarios(Guid empresaId) : IQuery<EmpresaFuncionariosDto>;
}
