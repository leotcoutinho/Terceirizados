using Mediator;
using Terceirizados.Aplicacao.Dtos;
using Terceirizados.Dominio.Repositorios;

namespace Terceirizados.Aplicacao.Empresas.Consultas.Listar
{
    public class ExecutarListarEmpresas(IRepositorioEmpresa repositorioEmpresa) :
        IQueryHandler<ConsultaListarEmpresas, ICollection<EmpresaDto>>
    {
        public async ValueTask<ICollection<EmpresaDto>> Handle(ConsultaListarEmpresas query, CancellationToken cancellationToken)
        {
            var empresas = await repositorioEmpresa.ListarTodos(cancellationToken);

            return empresas.Select(e => new EmpresaDto(
                 e.EmpresaId,
                 e.RazaoSocial,
                 e.Cnpj
             )).ToList();

        }
    }
}
