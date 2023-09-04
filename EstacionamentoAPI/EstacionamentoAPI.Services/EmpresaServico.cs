using AutoMapper;
using EstacionamentoAPI.Domain.DTO;
using EstacionamentoAPI.Domain.Entidades;
using EstacionamentoAPI.Domain.ViewModel;
using EstacionamentoAPI.Repository.Contratos;
using EstacionamentoAPI.Services.Contratos;

namespace EstacionamentoAPI.Services
{
    public class EmpresaServico : IEmpresaServico
    {
        private readonly IEmpresaRepositorio _empresaRepositorio;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public EmpresaServico(IEmpresaRepositorio empresaRepositorio, IMapper mapper, INotificationService notificationService)
        {
            _empresaRepositorio = empresaRepositorio;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        public async Task<EmpresaDTO> AddAsync(AddEmpresa vm)
        {
            var entity = _mapper.Map<Domain.Entidades.Empresa>(vm);
            entity = await _empresaRepositorio.AddAsync(entity);

            return _mapper.Map<EmpresaDTO>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _empresaRepositorio.GetAsync(id);

            if (data != null)
            {
                var dto = _mapper.Map<EmpresaDTO>(data);
                dto.ExcluidoEm = DateTime.Now;
                dto.Excluido = true;
                await _empresaRepositorio.UpdateAsync(_mapper.Map<Empresa>(dto));
            }
            else
            {
                _notificationService.Notification.Errors.Add("Empresa não encontrada");
            }
        }

        public async Task<List<EmpresaDTO>> GetAll()
        {
            var data = await _empresaRepositorio.GetAll();
            return _mapper.Map<List<EmpresaDTO>>(data);
        }

        public async Task<EmpresaDTO> GetAsync(int id)
        {
            var data = await _empresaRepositorio.GetAsync(id);
            return _mapper.Map<EmpresaDTO>(data);
        }

        public async Task<EmpresaDTO> GetRegister(int empresaId, DateTime dataEntrada, DateTime dataSaida)
        {
            var data = await _empresaRepositorio.GetRegister(empresaId, dataEntrada, dataSaida);
            return _mapper.Map<EmpresaDTO>(data);
        }

        public async Task UpdateAsync(UpEmpresa dto)
        {
            var data = await _empresaRepositorio.GetAsync(dto.Id.Value);

            if (data != null)
            {
                var up = _mapper.Map(dto, data);
                await _empresaRepositorio.UpdateAsync(_mapper.Map<Empresa>(up));
            }
            else
            {
                _notificationService.Notification.Errors.Add("Empresa não encontrada");
            }
        }
    }
}
