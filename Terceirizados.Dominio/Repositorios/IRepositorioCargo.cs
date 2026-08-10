using Terceirizados.Dominio.Entidades;

namespace Terceirizados.Dominio.Repositorios
{
    public interface IRepositorioCargo
    {
        Task<ICollection<Cargo>> ListarTodos(CancellationToken cancellationToken = default);
        Task<Cargo?> BuscarPorId(Guid id, CancellationToken cancellationToken = default);
    }
}
