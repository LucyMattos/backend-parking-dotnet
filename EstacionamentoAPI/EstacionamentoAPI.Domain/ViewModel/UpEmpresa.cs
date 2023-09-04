namespace EstacionamentoAPI.Domain.ViewModel
{
    public class UpEmpresa
    {
        public int? Id { get; set; }
        public string? Nome { get;  set; }
        public string? CNPJ { get;  set; }
        public string? Endereco { get;  set; }
        public string? Telefone { get;  set; }
        public int? VagasParaCarros { get;  set; }
        public int? VagasParaMotos { get;  set; }
    }
}
