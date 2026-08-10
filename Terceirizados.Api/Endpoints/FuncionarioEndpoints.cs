using Mediator;
using Terceirizados.Aplicacao.FuncionarioApp.Comandos.Cadastrar;
using Terceirizados.Aplicacao.FuncionarioApp.Consultas.Listar;

namespace Terceirizados.Api.Endpoints
{
    public class FuncionarioEndpoints : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/funcionarios", ListarFuncionarios);
            app.MapPost("/funcionarios", CadastrarFuncionario);
        }

        private static async Task<IResult> ListarFuncionarios(IMediator mediator, ConsultaListarFuncionarios consulta)
        {
            var funcionarios = await mediator.Send(consulta);
            return Results.Ok(funcionarios);
        }

        private static async Task<IResult> CadastrarFuncionario(IMediator mediator, ComandoCadastrarFuncionario comando)
        {
            var id = await mediator.Send(comando);
            return Results.Created($"/funcionarios/{id}", new { id });
        }
    }
}
