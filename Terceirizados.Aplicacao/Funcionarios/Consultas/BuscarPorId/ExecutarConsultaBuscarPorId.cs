using Mediator;
using Terceirizados.Aplicacao.Dtos;
using Terceirizados.Dominio.Repositorios;

namespace Terceirizados.Aplicacao.Funcionarios.Consultas.BuscarPorId
{
    public class ExecutarConsultaBuscarPorId(IRepositorioFuncionario repositorioFuncionario) : IQueryHandler<ConsultaBuscarPorId, FuncionarioDto>
    {
        public async ValueTask<FuncionarioDto> Handle(ConsultaBuscarPorId query, CancellationToken cancellationToken)
        {
            var funcionario = await repositorioFuncionario.BuscarPorId(query.funcionarioId, cancellationToken);

            if (funcionario == null)
                throw new Exception($"Funcionário não encontrado");

            return new FuncionarioDto(
                funcionario.FuncionarioId,
                funcionario.Nome,
                funcionario.Cpf,
                funcionario.DataNascimento,
                funcionario.Email,
                funcionario.Telefone,
                funcionario.EmpresaId,
                funcionario.CargoId
            );
        }
    }
}
