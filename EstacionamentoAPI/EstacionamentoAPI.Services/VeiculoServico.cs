using AutoMapper;
using EstacionamentoAPI.Domain.DTO;
using EstacionamentoAPI.Domain.Entidades;
using EstacionamentoAPI.Domain.ViewModel;
using EstacionamentoAPI.Repository.Contratos;
using EstacionamentoAPI.Repository.Repositorios;
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

        public async Task<List<VeiculoDTO>> GetAll()
        {
            var data = await _veiculoRepositorio.GetAll();
            return _mapper.Map<List<VeiculoDTO>>(data);
        }

        public async Task<VeiculoDTO> AddAsync(AddVeiculo vm)
        {
            {
                var entity = _mapper.Map<Domain.Entidades.Veiculo>(vm);
                entity = await _veiculoRepositorio.AddAsync(entity);

                return _mapper.Map<VeiculoDTO>(entity);
            }
        }

        public async Task UpdateAsync(UpVeiculo dto)
        {
            var data = await _veiculoRepositorio.GetAsync(dto.Id);

            if (data != null )
            {
                var up = _mapper.Map(dto, data);
                await _veiculoRepositorio.UpdateAsync(_mapper.Map<Veiculo>(up));
            }
        }
        public async Task DeleteAsync(int id)
        {
            var data = await _veiculoRepositorio.GetAsync(id);
           
            if (data != null)
            {
                var dto = _mapper.Map<VeiculoDTO>(data);
                dto.ExcluidoEm = DateTime.Now;
                dto.Excluido = true;
                await _veiculoRepositorio.UpdateAsync(_mapper.Map<Veiculo>(dto));
            }
        }
    }
}
