using EstacionamentoAPI.Domain.Enum;

namespace EstacionamentoAPI.Domain.DTO
{
    public class VeiculoDTO : BaseDTO
    {
        public int EmpresaId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public TipoVeiculoEnum Tipo { get; set; }
    }
}
