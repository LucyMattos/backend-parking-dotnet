using EstacionamentoAPI.Domain.DTO;

namespace EstacionamentoAPI.Services.Contratos
{
    public interface IVeiculoServico
    {
        Task<VeiculoDTO> GetAsync(int id);
    }
}