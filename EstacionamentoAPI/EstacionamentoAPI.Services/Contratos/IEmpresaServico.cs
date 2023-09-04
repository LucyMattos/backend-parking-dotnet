using EstacionamentoAPI.Domain.DTO;
using EstacionamentoAPI.Domain.ViewModel;

namespace EstacionamentoAPI.Services.Contratos
{
    public interface IEmpresaServico
    {
        Task<EmpresaDTO> GetAsync(int id);
        Task<List<EmpresaDTO>> GetAll();
        Task<EmpresaDTO> AddAsync(AddEmpresa vm);
        Task UpdateAsync(UpEmpresa dto);
        Task DeleteAsync(int id);
        Task<EmpresaDTO> GetRegister(int empresaId, DateTime dataEntrada, DateTime dataSaida);
    }
}
