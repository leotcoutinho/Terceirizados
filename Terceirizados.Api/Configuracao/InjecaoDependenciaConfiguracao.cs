using Terceirizados.Dominio.Fabricas;
using Terceirizados.Dominio.Repositorios;
using Terceirizados.Infraestrutura.Repositorios;

namespace Terceirizados.Api.Configuracao
{
    public static class InjecaoDependenciaConfiguracao
    {
        public static IServiceCollection AddInjecaoDependencia(this IServiceCollection services)
        {
            services.AddScoped<IRepositorioCargo, RepositorioCargo>();
            services.AddScoped<IRepositorioEmpresa, RepositorioEmpresa>();
            services.AddScoped<IRepositorioFuncionario, RepositorioFuncionario>();

            services.AddScoped(typeof(FabricaEmpresa));

            return services;
        }
    }
}
