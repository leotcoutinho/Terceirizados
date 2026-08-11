using Terceirizados.Dominio.Entidades;

namespace Terceirizados.Dominio.Repositorios
{
    public interface IRepositorioEmpresa
    {
        Task<ICollection<Empresa>> ListarTodos(CancellationToken cancellationToken = default);
        Task<Empresa?> BuscarPorId(Guid id, CancellationToken cancellationToken = default);
        Task<Empresa?> BuscarPorCnpj(string cnpj, CancellationToken cancellationToken = default);
        Task<Empresa?> BuscarEmpresaComFuncionarios(Guid empresaId, CancellationToken cancellationToken = default);
        Task<Guid> Inserir(Empresa empresa, CancellationToken cancellationToken = default);
        Task Atualizar(Empresa empresa);
        Task Remover(Empresa empresa);
    }
}
