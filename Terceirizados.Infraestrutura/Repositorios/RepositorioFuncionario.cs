using Microsoft.EntityFrameworkCore;
using Terceirizados.Dominio.Entidades;
using Terceirizados.Dominio.Repositorios;
using Terceirizados.Infraestrutura.Contexto;

namespace Terceirizados.Infraestrutura.Repositorios
{
    public class RepositorioFuncionario(DadosContexto contexto) : IRepositorioFuncionario
    {
        public async Task<ICollection<Funcionario>> ListarTodos(CancellationToken cancellationToken)
        {
            return await contexto.Funcionarios.ToListAsync(cancellationToken);
        }

        public async Task<Funcionario?> ListarPorEmpresa(Guid empresaId, CancellationToken cancellationToken)
        {
            return await contexto.Funcionarios.Where(f => f.EmpresaId == empresaId).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Funcionario?> BuscarPorId(Guid funcionarioId, CancellationToken cancellationToken = default)
        {
            return await contexto.Funcionarios.FindAsync(funcionarioId, cancellationToken);
        }

        public async Task<Guid> Inserir(Funcionario funcionario)
        {
            await contexto.AddAsync(funcionario);
            await contexto.SaveChangesAsync();

            return funcionario.FuncionarioId;
        }

        public async Task Atualizar(Funcionario funcionario)
        {
            contexto.Update(funcionario);
            await contexto.SaveChangesAsync();
        }

        public async Task Remover(Funcionario funcionario)
        {
            contexto.Remove(funcionario);
            await contexto.SaveChangesAsync();
        }
    }
}
