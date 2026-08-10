using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Terceirizados.Dominio.Entidades;

namespace Terceirizados.Infraestrutura.Mapeamento
{
    public class CargoMap : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> entidade)
        {
            entidade.ToTable("T_Cargo");

            entidade.HasKey(x => x.CargoId)
                .HasName("PK_T_Cargo");

            entidade.Property(x => x.CargoId)
                .HasColumnName("Cargo_Id")
                .IsRequired();

            entidade.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
