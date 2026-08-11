using Mediator;

namespace Terceirizados.Aplicacao.Empresas.Comandos.Cadastrar
{
    public record ComandoCadastrarEmpresa(string RazaoSocial, string Cnpj) : ICommand<Guid>;
    
}
