using Mediator;
using Terceirizados.Aplicacao.Dtos;

namespace Terceirizados.Aplicacao.Funcionarios.Consultas.BuscarPorId
{
    public record ConsultaBuscarPorId(Guid funcionarioId) : IQuery<FuncionarioDto>;
}
