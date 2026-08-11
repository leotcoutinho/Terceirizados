using Microsoft.EntityFrameworkCore;
using Terceirizados.Dominio.Entidades;
using Terceirizados.Dominio.Repositorios;
using Terceirizados.Infraestrutura.Contexto;

namespace Terceirizados.Infraestrutura.Repositorios
{
    public class RepositorioEmpresa(DadosContexto contexto) : IRepositorioEmpresa
    {
        public async Task<ICollection<Empresa>> ListarTodos(CancellationToken cancellationToken)
        {
            return await contexto.Empresas.ToListAsync(cancellationToken);
        }

        public async Task<Empresa?> BuscarPorId(Guid id, CancellationToken cancellationToken = default)
        {
            return await contexto.Empresas.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<Empresa?> BuscarPorCnpj(string cnpj, CancellationToken cancellationToken = default)
        {
            return await contexto.Empresas.Where(x => x.Cnpj == cnpj).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Empresa?> BuscarEmpresaComFuncionarios(Guid empresaId, CancellationToken cancellationToken = default)
        {
            return await contexto.Empresas.Where(x => x.EmpresaId == empresaId).Include(e => e.Funcionarios).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Guid> Inserir(Empresa empresa, CancellationToken cancellationToken = default)
        {
            await contexto.Empresas.AddAsync(empresa, cancellationToken);
            await contexto.SaveChangesAsync();
            return empresa.EmpresaId;
        }

        public async Task Atualizar(Empresa empresa)
        {
            contexto.Empresas.Update(empresa);
            await contexto.SaveChangesAsync();
        }

        public async Task Remover(Empresa empresa)
        {
            contexto.Empresas.Remove(empresa);
            await contexto.SaveChangesAsync();
            await contexto.SaveChangesAsync();
        }
    }
}
