namespace EstacionamentoAPI.Domain.Entidades
{
    public class Empresa : Base
    {
        public Empresa()
        {

        }
        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }
        public string VagasParaCarros { get; private set; }
        public string VagasParaMotos { get; private set; }
        public IEnumerable<Veiculo>? Veiculos { get;  private set; }
    }
}