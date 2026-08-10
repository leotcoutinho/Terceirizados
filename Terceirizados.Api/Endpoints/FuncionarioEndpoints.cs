using Mediator;
using Terceirizados.Aplicacao.FuncionarioApp.Comandos.Cadastrar;

namespace Terceirizados.Api.Endpoints
{
    public class FuncionarioEndpoints : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/funcionarios", CadastrarFuncionario);
        }

        private static async Task<IResult> CadastrarFuncionario(IMediator mediator, ComandoCadastrarFuncionario comando)
        {
            var id = await mediator.Send(comando);
            return Results.Created($"/funcionarios/{id}", new { id });
        }
    }
}
