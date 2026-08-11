using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Terceirizados.Dominio.Entidades;

namespace Terceirizados.Infraestrutura.Mapeamento
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> entidade)
        {
            entidade.ToTable("T_Funcionario");

            entidade.HasKey(x => x.FuncionarioId)
                .HasName("PK_T_Funcionario");

            entidade.Property(x => x.FuncionarioId)
                .HasColumnName("Funcionario_Id")
                .IsRequired();

            entidade.Property(x => x.CargoId)
                .HasColumnName("Cargo_Id")
                .IsRequired();

            entidade.Property(x => x.EmpresaId)
                .HasColumnName("Empresa_Id")
                .IsRequired();

            entidade.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();

            entidade.Property(x => x.DataNascimento)
            .HasColumnName("Data_Nascimento")
            .IsRequired();

            entidade.Property(x => x.Cpf)
                .HasColumnName("Cpf")
                .HasMaxLength(11)
                .IsRequired();

            entidade.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsRequired();

            entidade.Property(x => x.Telefone)
                .HasColumnName("Telefone")
                .HasMaxLength(15);

            entidade.Property(x => x.Ativo)
                .HasColumnName("Ativo");

            // relacionamento com Empresa
            entidade.HasOne(e => e.Empresa)
                .WithMany(f => f.Funcionarios)
                .HasForeignKey(f => f.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            // relacionamento com Cargo
            entidade.HasOne(c => c.Cargo)
                .WithOne(f => f.Funcionario)
                .HasForeignKey<Funcionario>(f => f.CargoId);

        }
    }
}
