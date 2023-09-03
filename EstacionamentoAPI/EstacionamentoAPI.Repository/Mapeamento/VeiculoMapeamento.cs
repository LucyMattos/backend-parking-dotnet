using EstacionamentoAPI.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstacionamentoAPI.Repository.Mapeamento
{
    public class VeiculoMapeamento : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculos");
            builder.HasKey(p => p.Id)
                .HasName("PK_Veiculos");

            builder.Property(p => p.Id)
                .HasColumnType("INT")
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(p => p.EmpresaId)
              .HasColumnType("INT")
              .IsRequired();

            builder.Property(p => p.Marca)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(p => p.Modelo)
               .HasColumnType("VARCHAR(100)")
               .IsRequired();

            builder.Property(p => p.Cor)
               .HasColumnType("VARCHAR(50)")
               .IsRequired();

            builder.Property(p => p.Placa)
               .HasColumnType("VARCHAR(20)")
               .IsRequired();

            builder.Property(p => p.Tipo)
               .HasColumnType("INT")
               .IsRequired();

            builder.Property(p => p.DataEntrada)
              .HasDefaultValueSql("GETUTCDATE()")
              .IsRequired();

            builder.Property(p => p.DataSaida)
             .IsRequired(false);

            builder.Property(p => p.ExcluidoEm)
              .IsRequired(false);

            builder.Property(p => p.UltimaAtualizacao).IsRequired(false);
            builder.Property(p => p.Excluido).IsRequired(true).HasDefaultValue(false);
        }
    }
}
