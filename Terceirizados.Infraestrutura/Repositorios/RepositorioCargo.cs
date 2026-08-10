using Microsoft.EntityFrameworkCore;
using Terceirizados.Dominio.Entidades;
using Terceirizados.Dominio.Repositorios;
using Terceirizados.Infraestrutura.Contexto;

namespace Terceirizados.Infraestrutura.Repositorios
{
    public class RepositorioCargo(DadosContexto contexto) : IRepositorioCargo
    {
        public async Task<ICollection<Cargo>> ListarTodos(CancellationToken cancellationToken)
        {
            return await contexto.Cargos.ToListAsync(cancellationToken);
        }

        public async Task<Cargo?> BuscarPorId(Guid id, CancellationToken cancellationToken = default)
        {
            return await contexto.Cargos.FindAsync(new object[] { id }, cancellationToken);
        }
    }
}
