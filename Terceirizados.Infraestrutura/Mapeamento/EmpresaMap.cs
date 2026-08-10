using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Terceirizados.Dominio.Entidades;

namespace Terceirizados.Infraestrutura.Mapeamento
{
    internal class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> entidade)
        {
            entidade.ToTable("T_Empresa");

            entidade.HasKey(x => x.EmpresaId)
                .HasName("PK_T_Empresa");

            entidade.Property(x => x.EmpresaId)
                .HasColumnName("Empresa_Id")
                .IsRequired();

            entidade.Property(x => x.RazaoSocial)
                .HasColumnName("Razao_Social")
                .HasMaxLength(100)
                .IsRequired();
            
            entidade.Property(x => x.Cnpj)
                .HasColumnName("Cnpj")
                .HasMaxLength(14)
                .IsRequired();
        }
    }
}