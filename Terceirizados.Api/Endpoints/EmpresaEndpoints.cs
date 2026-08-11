using Mediator;
using Terceirizados.Aplicacao.Empresas.Comandos.Cadastrar;
using Terceirizados.Aplicacao.Empresas.Comandos.Remover;
using Terceirizados.Aplicacao.Empresas.Consultas.BuscarEmpresaComFuncionarios;
using Terceirizados.Aplicacao.Empresas.Consultas.BuscarPorId;
using Terceirizados.Aplicacao.Empresas.Consultas.Listar;

namespace Terceirizados.Api.Endpoints
{
    public class EmpresaEndpoints : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            var api = app.MapGroup("/api");

            api.MapGet("/empresas", ListarEmpresas);
            api.MapGet("/empresas/{id:guid}", BuscarPorId);
            api.MapGet("/empresas/empresa-funcionarios/{id:guid}", BuscarEmpresaComFuncionarios);
            api.MapPost("/empresas", CriarEmpresa);
            api.MapDelete("/empresas/{id:guid}", RemoverEmpresa);
        }

        private static async Task<IResult> RemoverEmpresa(IMediator mediator, Guid Id)
        {
            await mediator.Send(new ComandoRemoverEmpresa(Id));
            return Results.Ok();
        }

        private static async Task<IResult> BuscarEmpresaComFuncionarios(IMediator mediator, Guid Id)
        {
            var empresa = await mediator.Send(new ConsultaBuscarEmpresaComFuncionarios(Id));

            if (empresa == null)
                return Results.NotFound();

            return Results.Ok(empresa);
        }

        private static async Task<IResult> BuscarPorId(IMediator mediator, Guid Id)
        {
            var empresa = await mediator.Send(new ConsultaBuscarPorId(Id));

            if (empresa == null)
                return Results.NotFound();

            return Results.Ok(empresa);
        }

        private static async Task<IResult> CriarEmpresa(IMediator mediator, ComandoCadastrarEmpresa comandoCadastrarEmpresa)
        {
            Guid id = await mediator.Send(comandoCadastrarEmpresa);

            return Results.Created($"/empresas/{id}", new { id });
        }

        public static async Task<IResult> ListarEmpresas(IMediator mediator)
        {
            var empresas = await mediator.Send(new ConsultaListarEmpresas());

            return Results.Ok(empresas);
        }
    }
}
