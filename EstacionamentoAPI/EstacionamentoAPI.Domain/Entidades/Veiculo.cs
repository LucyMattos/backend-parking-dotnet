namespace EstacionamentoAPI.Domain.Entidades
{
    public class Veiculo : Base
    {
        public Veiculo()
        {

        }
        public string Marca { get; private set; } 
        public string Modelo { get; private set; } 
        public string Cor { get; private set; } 
        public string Placa { get; private set; } 
        public string Tipo { get; private set; }
    }
}
