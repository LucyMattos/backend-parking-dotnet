namespace EstacionamentoAPI.Domain.Entidades
{
    public class Veiculo : Base
    {
        public Veiculo(int empresaId, string marca, string modelo, string cor, string placa, string tipo)
        {
            EmpresaId = empresaId;
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
            Placa = placa;
            Tipo = tipo;
        }

        private Veiculo() { }

        public int EmpresaId { get; private set; }
        public string Marca { get; private set; } 
        public string Modelo { get; private set; } 
        public string Cor { get; private set; } 
        public string Placa { get; private set; } 
        public string Tipo { get; private set; }
        public Empresa Empresa { get; private set; }    
    }
}
