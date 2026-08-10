using Mediator;
using Terceirizados.Aplicacao.EmpresaApp.Comandos.Cadastrar;
using Terceirizados.Aplicacao.EmpresaApp.Consultas.BusarEmpresaComFuncionarios;
using Terceirizados.Aplicacao.Empresas.Consultas.BuscarPorId;
using Terceirizados.Aplicacao.Empresas.Consultas.Listar;

namespace Terceirizados.Api.Endpoints
{
    public class EmpresaEndpoints : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("empresas", ListarEmpresas);
            app.MapGet("empresas/{id:guid}", BuscarPorId).WithName("BuscarPorId");
            app.MapGet("empresas/empresa-funcionarios/{id:guid}", BuscarEmpresaComFuncionarios);
            app.MapPost("empresas", CriarEmpresa);
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

            if(empresa == null) 
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
            var query = new ConsultaListarEmpresas();
            var empresas = await mediator.Send(query);

            return Results.Ok(empresas);
        }
    }
}
