using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Terceirizados.Api.Configuracao;
using Terceirizados.Infraestrutura.Contexto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddInjecaoDependencia();

builder.Services.AddDbContext<DadosContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediator(options =>
{
    options.ServiceLifetime = ServiceLifetime.Scoped;
});

var app = builder.Build();

app.MapEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(opt => opt.WithTitle("Terceirizados API")
    .WithTheme(ScalarTheme.Default)
    .ForceDarkMode());
}


app.Run();


