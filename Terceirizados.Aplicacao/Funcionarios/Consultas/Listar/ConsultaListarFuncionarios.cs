using Mediator;
using Terceirizados.Aplicacao.Dtos;

namespace Terceirizados.Aplicacao.Funcionarios.Consultas.Listar
{
    public record ConsultaListarFuncionarios() : IQuery<ICollection<FuncionarioDto>>; 
    
}
