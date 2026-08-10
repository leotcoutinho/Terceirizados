using System.Reflection;
using Terceirizados.Api.Endpoints;

namespace Terceirizados.Api.Configuracao
{
    public static class EndpointsConfiguracao
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endpointTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IEndpoint).IsAssignableFrom(t));

            foreach (var type in endpointTypes)
            {
                // Chama o método estático MapEndpoint via reflection
                type.GetMethod(nameof(IEndpoint.MapEndpoint))!
                    .Invoke(null, [app]);
            }
        }
    }
}
