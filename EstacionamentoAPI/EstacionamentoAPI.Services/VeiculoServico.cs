using AutoMapper;
using EstacionamentoAPI.Domain.DTO;
using EstacionamentoAPI.Domain.Entidades;
using EstacionamentoAPI.Domain.ViewModel;
using EstacionamentoAPI.Repository.Contratos;
using EstacionamentoAPI.Services.Contratos;

namespace EstacionamentoAPI.Services
{
    public class VeiculoServico : IVeiculoServico
    {
        private readonly IVeculoRepositorio _veiculoRepositorio;
        private readonly IEmpresaRepositorio _empresaRepositorio;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public VeiculoServico(IVeculoRepositorio veiculoRepositorio, IMapper mapper, IEmpresaRepositorio empresaRepositorio, INotificationService notificationService)
        {
            _veiculoRepositorio = veiculoRepositorio;
            _mapper = mapper;
            _empresaRepositorio = empresaRepositorio;
            _notificationService = notificationService;
        }

        public async Task<VeiculoDTO> GetAsync(int id, int empresaId)
        {
            var data = await _veiculoRepositorio.GetAsync(id, empresaId);
            return _mapper.Map<VeiculoDTO>(data);
        }

        public async Task<List<VeiculoDTO>> GetAll()
        {
            var data = await _veiculoRepositorio.GetAll();
            return _mapper.Map<List<VeiculoDTO>>(data);
        }

        public async Task<VeiculoDTO> AddAsync(AddVeiculo vm)
        {
            var empresa = await _empresaRepositorio.GetAsync(vm.EmpresaId.Value);

            if (empresa == null)
            {
                _notificationService.Notification.Errors.Add("Empresa não encontrada");
                return null;
            }

            if (vm.TipoVeiculoEnum == Domain.Enum.TipoVeiculoEnum.Carro)
            {
                var carros = empresa.Veiculos?.Where(e => e.Tipo == Domain.Enum.TipoVeiculoEnum.Carro);

                if (empresa.VagasParaCarros <= carros.Count())
                    _notificationService.Notification.Errors.Add("Não há vagas para carros");
            }

            if (vm.TipoVeiculoEnum == Domain.Enum.TipoVeiculoEnum.Moto)
            {
                var motos = empresa.Veiculos?.Where(e => e.Tipo == Domain.Enum.TipoVeiculoEnum.Moto);
                if (empresa.VagasParaMotos <= motos.Count())
                    _notificationService.Notification.Errors.Add("Não há vagas para carros");
            }

            if (empresa.Veiculos.Select(x => x.Placa.Contains(vm.Placa)).FirstOrDefault())
                _notificationService.Notification.Errors.Add("Veículo já cadastrado");

            if (_notificationService.HasErrors) return null;

            var entity = _mapper.Map<Domain.Entidades.Veiculo>(vm);
            entity = await _veiculoRepositorio.AddAsync(entity);

            return _mapper.Map<VeiculoDTO>(entity);
        }

        public async Task UpdateAsync(UpVeiculo dto)
        {
            var data = await _veiculoRepositorio.GetAsync(dto.Id.Value, dto.EmpresaId.Value);

            if (data != null)
            {
                var up = _mapper.Map(dto, data);
                await _veiculoRepositorio.UpdateAsync(_mapper.Map<Veiculo>(up));
            }
        }

        public async Task ParkingExitAsync(int empresaId, int veiculoId)
        {
            var data = await _veiculoRepositorio.GetAsync(veiculoId, empresaId);

            if (data == null)
                _notificationService.Notification.Errors.Add("Veículo não encontrado");

            if (_notificationService.HasErrors) return;

            if (data != null)
            {
                var dto = _mapper.Map<VeiculoDTO>(data);
                dto.DataSaida = DateTime.Now;
                await _veiculoRepositorio.UpdateAsync(_mapper.Map<Veiculo>(dto));
            }
        }

        public async Task DeleteAsync(int id, int empresaId)
        {
            var data = await _veiculoRepositorio.GetAsync(id, empresaId);

            if (data == null)
                _notificationService.Notification.Errors.Add("Veículo não encontrado");

            if (_notificationService.HasErrors) return;

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
