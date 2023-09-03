﻿using EstacionamentoAPI.Domain.DTO;
using EstacionamentoAPI.Domain.ViewModel;

namespace EstacionamentoAPI.Services.Contratos
{
    public interface IVeiculoServico
    {
        Task<VeiculoDTO> GetAsync(int id, int empresaId);
        Task<List<VeiculoDTO>> GetAll();
        Task<VeiculoDTO> AddAsync(AddVeiculo vm);
        Task UpdateAsync(UpVeiculo dto);
        Task DeleteAsync(int id, int empresaId);
        Task ParkingExitAsync(int empresaId, int veiculoId);
    }
}