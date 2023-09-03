using EstacionamentoAPI.Domain.Entidades;
using EstacionamentoAPI.Domain.Enum;
using EstacionamentoAPI.Repository.Mapeamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EstacionamentoAPI.Repository.Contexto
{
    public class EstacionamentoContext : DbContext
    {
        public EstacionamentoContext()
        {
        }
        public EstacionamentoContext(DbContextOptions<EstacionamentoContext> options)
           : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    var property = entityEntry.Properties.FirstOrDefault(p => p.Metadata.Name == "DataCriacao");
                    if (property != null)
                        entityEntry.Property("DataCriacao").CurrentValue = DateTimeOffset.UtcNow;
                    
                    property = entityEntry.Properties.FirstOrDefault(p => p.Metadata.Name == "Excluido");
                    if (property != null)
                    {
                        entityEntry.Property("Excluido").CurrentValue = false;
                    }
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    var property = entityEntry.Properties.FirstOrDefault(p => p.Metadata.Name == "UltimaAtualizacao");
                    if (property != null)
                        entityEntry.Property("UltimaAtualizacao").CurrentValue = DateTimeOffset.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.ApplyConfiguration(new EmpresaMapeamento());
            modelBuilder.ApplyConfiguration(new VeiculoMapeamento());
        }
    }
}
