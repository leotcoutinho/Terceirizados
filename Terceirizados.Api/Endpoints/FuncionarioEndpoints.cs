using Mediator;
using Terceirizados.Aplicacao.Funcionarios.Comandos.Cadastrar;
using Terceirizados.Aplicacao.Funcionarios.Comandos.Remover;
using Terceirizados.Aplicacao.Funcionarios.Consultas.BuscarPorId;
using Terceirizados.Aplicacao.Funcionarios.Consultas.Listar;

namespace Terceirizados.Api.Endpoints
{
    public class FuncionarioEndpoints : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("/api");

            api.MapGet("/funcionarios", ListarFuncionarios);
            api.MapGet("/funcionarios/{id:guid}", BuscarPorId);
            api.MapPost("/funcionarios", CadastrarFuncionario);
            api.MapDelete("/funcionarios/{id:guid}", RemoverFuncionario);   
        }

        private static async Task<IResult> RemoverFuncionario(IMediator mediator, Guid id)
        {
           await mediator.Send(new ComandoRemoverFuncionario(id));
           return Results.NoContent();
        }

        private static async Task<IResult> ListarFuncionarios(IMediator mediator)
        {
            var funcionarios = await mediator.Send(new ConsultaListarFuncionarios());
            return Results.Ok(funcionarios);
        }

        private static async Task<IResult> BuscarPorId(IMediator mediator, Guid id)
        {
            var funcionario = await mediator.Send(new ConsultaBuscarPorId(id));
            return Results.Ok(funcionario);
        }

        private static async Task<IResult> CadastrarFuncionario(IMediator mediator, ComandoCadastrarFuncionario comando)
        {
            var id = await mediator.Send(comando);
            return Results.Created($"/funcionarios/{id}", new { id });
        }
    }
}
