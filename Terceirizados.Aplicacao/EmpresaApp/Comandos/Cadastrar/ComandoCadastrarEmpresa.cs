using Mediator;

namespace Terceirizados.Aplicacao.EmpresaApp.Comandos.Cadastrar
{
    public record ComandoCadastrarEmpresa(string RazaoSocial, string Cnpj) : ICommand<Guid>;
    
}
