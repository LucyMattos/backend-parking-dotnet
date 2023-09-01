using AutoMapper;
using EstacionamentoAPI.Domain.DTO;
using EstacionamentoAPI.Repository.Contratos;
using EstacionamentoAPI.Services.Contratos;

namespace EstacionamentoAPI.Services
{
    public class VeiculoServico : IVeiculoServico
    {
        private readonly IVeculoRepositorio _veiculoRepositorio;
        private readonly IMapper _mapper;
        public VeiculoServico(IVeculoRepositorio veiculoRepositorio, IMapper mapper)
        {
            _veiculoRepositorio = veiculoRepositorio;
            _mapper = mapper;
        }

        public async Task<VeiculoDTO> GetAsync(int id)
        {
            var data = await _veiculoRepositorio.GetAsync(id);
            return _mapper.Map<VeiculoDTO>(data);
        }
    }
}
