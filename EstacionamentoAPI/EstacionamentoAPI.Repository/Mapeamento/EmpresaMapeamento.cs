using EstacionamentoAPI.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstacionamentoAPI.Repository.Mapeamento
{
    public class EmpresaMapeamento : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas");
            builder.HasKey(p => p.Id)
                .HasName("PK_Empresas");

            builder.Property(p => p.Id)
                .HasColumnType("INT")
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnType("VARCHAR(150)")
                .IsRequired();

            builder.Property(p => p.CNPJ)
               .HasColumnType("VARCHAR(20)")
               .IsRequired();

            builder.Property(p => p.Endereco)
               .HasColumnType("VARCHAR(150)")
               .IsRequired();

            builder.Property(p => p.Telefone)
               .HasColumnType("VARCHAR(20)")
               .IsRequired();

            builder.Property(p => p.VagasParaCarros)
               .HasColumnType("INT")
               .IsRequired();

            builder.Property(p => p.VagasParaMotos)
               .HasColumnType("INT")
               .IsRequired();

            builder.Property(p => p.DataCriacao)
              .HasDefaultValueSql("GETUTCDATE()")
              .IsRequired();

            builder.Property(p => p.ExcluidoEm)
                .IsRequired(false);

            builder.HasMany(p => p.Veiculos)
             .WithOne(p => p.Empresa)
             .HasForeignKey(fk => fk.EmpresaId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.UltimaAtualizacao).IsRequired(false);
            builder.Property(p => p.Excluido).IsRequired(true).HasDefaultValue(false);
        }
    }
    
}
