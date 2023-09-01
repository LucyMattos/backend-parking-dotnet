using EstacionamentoAPI.Domain.Entidades;
using EstacionamentoAPI.Repository.Contexto;
using EstacionamentoAPI.Repository.Contratos;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Repository.Repositorios
{
    public class EmpresaRepositorio : Repositorio<Empresa>, IEmpresaRepositorio
    {
        private readonly EstacionamentoContext _context;
        public EmpresaRepositorio(EstacionamentoContext context) : base(context)
        {
            _context = context;
        }
    }
}
