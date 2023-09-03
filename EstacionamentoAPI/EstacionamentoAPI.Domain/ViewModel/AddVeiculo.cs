using EstacionamentoAPI.Domain.Entidades;

namespace EstacionamentoAPI.Domain.ViewModel
{
    public class AddVeiculo
    {
        public int EmpresaId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string Tipo { get; set; }
    }
}
