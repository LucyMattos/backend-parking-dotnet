namespace EstacionamentoAPI.Domain.DTO
{
    public class VeiculoDTO : BaseDTO
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string Tipo { get; set; }
    }
}
