using Mediator;
using Terceirizados.Dominio.Entidades;
using Terceirizados.Dominio.Repositorios;

namespace Terceirizados.Aplicacao.Funcionarios.Comandos.Cadastrar
{
    public class ExecutarCadastrarFuncionario(IRepositorioFuncionario repositorioFuncionario) : ICommandHandler<ComandoCadastrarFuncionario, Guid>
    {
        public async ValueTask<Guid> Handle(ComandoCadastrarFuncionario command, CancellationToken cancellationToken)
        {
            var funcionario = new Funcionario(command.Nome, command.Cpf, command.DataNascimento, command.Telefone, command.Email, command.EmpresaId, command.CargoId);

            var id = await repositorioFuncionario.Inserir(funcionario);

            return id;
        }
    }
}
