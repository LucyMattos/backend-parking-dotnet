using AutoMapper;

namespace EstacionamentoAPI.Infra
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<Domain.DTO.EmpresaDTO, Domain.Entidades.Empresa>().ReverseMap();
            CreateMap<Domain.DTO.VeiculoDTO, Domain.Entidades.Veiculo>().ReverseMap();
            CreateMap<Domain.DTO.EmpresaDTO, Domain.ViewModel.AddEmpresa>().ReverseMap();
            CreateMap<Domain.Entidades.Empresa, Domain.ViewModel.AddEmpresa>().ReverseMap();
            CreateMap<Domain.DTO.EmpresaDTO, Domain.ViewModel.UpEmpresa>().ReverseMap();
            CreateMap<Domain.DTO.EmpresaDTO, Domain.Entidades.Empresa>().ReverseMap();
            CreateMap<Domain.ViewModel.UpEmpresa, Domain.Entidades.Empresa>().ReverseMap();
        }
    }
}
