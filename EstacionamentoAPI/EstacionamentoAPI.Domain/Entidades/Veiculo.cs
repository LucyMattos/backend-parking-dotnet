using EstacionamentoAPI.Domain.Enum;

namespace EstacionamentoAPI.Domain.Entidades
{
    public class Veiculo : Base
    {
        public Veiculo(int empresaId, string marca, string modelo, string cor, string placa, TipoVeiculoEnum tipo, DateTime? dataSaida, DateTime dataEntrada)
        {
            EmpresaId = empresaId;
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
            Placa = placa;
            Tipo = tipo;
            DataSaida = dataSaida;
            DataEntrada = dataEntrada;
        }

        private Veiculo() { }

        public int EmpresaId { get; private set; }
        public string Marca { get; private set; } 
        public string Modelo { get; private set; } 
        public string Cor { get; private set; } 
        public string Placa { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public DateTime? DataSaida { get; private set; }
        public TipoVeiculoEnum Tipo { get; private set; }
        public Empresa Empresa { get; private set; }
    }
}
