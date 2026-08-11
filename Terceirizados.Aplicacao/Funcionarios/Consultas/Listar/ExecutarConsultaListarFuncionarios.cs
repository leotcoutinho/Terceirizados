using Mediator;
using Terceirizados.Aplicacao.Dtos;
using Terceirizados.Dominio.Repositorios;

namespace Terceirizados.Aplicacao.Funcionarios.Consultas.Listar
{
    public class ExecutarConsultaListarFuncionarios(IRepositorioFuncionario repositorioFuncionario) : IQueryHandler<ConsultaListarFuncionarios, ICollection<FuncionarioDto>>
    {
        public async ValueTask<ICollection<FuncionarioDto>> Handle(ConsultaListarFuncionarios query, CancellationToken cancellationToken)
        {
            var funcionarios = await repositorioFuncionario.ListarTodos(cancellationToken);
            return funcionarios.Select(f => new FuncionarioDto(f.FuncionarioId, 
                                                               f.Nome, 
                                                               f.Cpf, 
                                                               f.DataNascimento, 
                                                               f.Email,
                                                               f.Telefone,
                                                               f.EmpresaId,
                                                               f.CargoId)).ToList();
        }
    }
}
