namespace EstacionamentoAPI.Domain.Entidades
{
    public class Empresa : Base
    {
        public Empresa(string nome, string cNPJ, string endereco, string telefone, int vagasParaCarros, int vagasParaMotos)
        {
            Nome = nome;
            CNPJ = cNPJ;
            Endereco = endereco;
            Telefone = telefone;
            VagasParaCarros = vagasParaCarros;
            VagasParaMotos = vagasParaMotos;
        }
        private Empresa() { }

        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }
        public int VagasParaCarros { get; private set; }
        public int VagasParaMotos { get; private set; }
        public IEnumerable<Veiculo>? Veiculos { get;  private set; }
    }
}