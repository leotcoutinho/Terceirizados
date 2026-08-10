using Terceirizados.Dominio.Entidades;

namespace Terceirizados.Dominio.Repositorios
{
    public interface IRepositorioFuncionario
    {
        Task<ICollection<Funcionario>> ListarTodos(CancellationToken cancellationToken = default);
        Task<Funcionario?> ListarPorEmpresa(Guid empresaId, CancellationToken cancellationToken = default);
        Task<Funcionario?> BuscarPorId(Guid funcionarioId, CancellationToken cancellationToken = default);
        Task<Guid> Inserir(Funcionario funcionario);
        Task Atualizar(Funcionario funcionario);
        Task Remover(Guid funcionarioId);
    }
}
