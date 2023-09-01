namespace EstacionamentoAPI.Domain.Entidades
{
    public class Base
    {
        protected Base()
        {
        }
        public int Id { get; protected set; }
        public DateTimeOffset? DataCriacao { get; protected set; }
        public DateTimeOffset? UltimaAtualizacao { get; protected set; }
        public bool Excluido { get; protected set; }
        public DateTimeOffset? ExcluidoEm { get; protected set; }
    }
}
