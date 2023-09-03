using EstacionamentoAPI.Domain.Entidades;
using EstacionamentoAPI.Domain.Enum;

namespace EstacionamentoAPI.Domain.ViewModel
{
    public class AddVeiculo
    {
        public int EmpresaId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public TipoVeiculoEnum TipoVeiculoEnum { get; set; }
    }
}
