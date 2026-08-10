using Mediator;
using Terceirizados.Aplicacao.Dtos;
using Terceirizados.Dominio.Entidades;

namespace Terceirizados.Aplicacao.FuncionarioApp.Consultas.Listar
{
    public record ConsultaListarFuncionarios() : IQuery<ICollection<FuncionarioDto>>; 
    
}
