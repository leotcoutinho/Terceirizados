using Mediator;
using Terceirizados.Aplicacao.Dtos;
using Terceirizados.Dominio.Repositorios;

namespace Terceirizados.Aplicacao.Empresas.Consultas.BuscarEmpresaComFuncionarios
{
    public class ExecutarBuscarEmpresaComFuncionarios(IRepositorioEmpresa repositorioEmpresa) : IQueryHandler<ConsultaBuscarEmpresaComFuncionarios, EmpresaFuncionariosDto>
    {
        public async ValueTask<EmpresaFuncionariosDto> Handle(ConsultaBuscarEmpresaComFuncionarios query, CancellationToken cancellationToken)
        {
            var empresa = await repositorioEmpresa.BuscarEmpresaComFuncionarios(query.empresaId);

            if (empresa is null)
                throw new InvalidOperationException($"Empresa {query.empresaId} not found.");

            var empresaComFuncionariosDto = new EmpresaFuncionariosDto(
                empresa.EmpresaId,
                empresa.RazaoSocial,
                empresa.Cnpj,
                empresa.Funcionarios.Select(f => new FuncionarioDto(
                    f.FuncionarioId,
                    f.Nome,
                    f.Cpf,
                    f.DataNascimento,
                    f.Email,
                    f.Telefone,
                    f.EmpresaId,
                    f.CargoId
                ))
            );     

            return empresaComFuncionariosDto;
        }
    }
}
