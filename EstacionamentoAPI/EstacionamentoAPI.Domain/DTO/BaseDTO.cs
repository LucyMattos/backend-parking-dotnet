namespace EstacionamentoAPI.Domain.DTO
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTimeOffset? DataCriacao { get; set; }
        public DateTimeOffset? UltimaAtualizacao { get; set; }
        public bool Excluido { get; set; }
        public DateTimeOffset? ExcluidoEm { get; set; }
    }
}
