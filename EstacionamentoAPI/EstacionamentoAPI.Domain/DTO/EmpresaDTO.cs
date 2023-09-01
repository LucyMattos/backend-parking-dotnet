namespace EstacionamentoAPI.Domain.DTO
{
    public class EmpresaDTO : BaseDTO
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string VagasParaCarros { get; set; }
        public string VagasParaMotos { get; set; }
        public IEnumerable<VeiculoDTO>? Veiculos { get; set; }
    }
}
