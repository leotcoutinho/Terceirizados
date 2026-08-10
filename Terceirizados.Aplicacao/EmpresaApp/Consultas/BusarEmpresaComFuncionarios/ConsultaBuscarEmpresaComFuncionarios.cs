using Mediator;
using Terceirizados.Aplicacao.Dtos;

namespace Terceirizados.Aplicacao.EmpresaApp.Consultas.BusarEmpresaComFuncionarios
{
    public record ConsultaBuscarEmpresaComFuncionarios(Guid empresaId) : IQuery<EmpresaFuncionariosDto>;
}
