using Microsoft.EntityFrameworkCore;
using Terceirizados.Dominio.Entidades;

namespace Terceirizados.Infraestrutura.Contexto
{
    public class DadosContexto(DbContextOptions<DadosContexto> options) : DbContext(options)    
    {
        public DbSet<Funcionario> Funcionarios { get; set; } 
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Cargo> Cargos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DadosContexto).Assembly);
        }
    }
}
