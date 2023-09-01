using EstacionamentoAPI.Domain.Entidades;
using EstacionamentoAPI.Repository.Contexto;
using EstacionamentoAPI.Repository.Contratos;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Repository.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : Base
    {
        private readonly EstacionamentoContext _context;

        public Repositorio(EstacionamentoContext context)
        {
            _context = context;
        }
    }
}
