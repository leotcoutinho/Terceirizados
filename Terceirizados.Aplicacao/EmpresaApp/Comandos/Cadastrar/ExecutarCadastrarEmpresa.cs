using Mediator;
using Terceirizados.Dominio.Entidades;
using Terceirizados.Dominio.Repositorios;

namespace Terceirizados.Aplicacao.EmpresaApp.Comandos.Cadastrar
{
    public class ExecutarCadastrarEmpresa(IRepositorioEmpresa repositorioEmpresa) : 
        ICommandHandler<ComandoCadastrarEmpresa, Guid>
    {
        public async ValueTask<Guid> Handle(ComandoCadastrarEmpresa command, CancellationToken cancellationToken)
        {
            var empresa = new Empresa(command.RazaoSocial, command.Cnpj);
            return await repositorioEmpresa.Inserir(empresa);
        }
    }
}
