using EstacionamentoAPI.Domain.Entidades;

namespace EstacionamentoAPI.Repository.Contratos
{
    public interface IVeculoRepositorio : IRepositorio<Veiculo>
    {
        Task<Veiculo> GetAsync(int id);
        Task<List<Veiculo>> GetAll();
    }
}
