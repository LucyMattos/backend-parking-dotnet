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

        public async Task<List<Empresa>> GetAll()
        {
            return await _context.Empresas.Where(e => !e.Excluido).Include(e => e.Veiculos).ToListAsync();
        }

        public async Task<Empresa> GetAsync(int id)
        {
            return await _context.Empresas.Where(e => e.Id == id && !e.Excluido).Include(v => v.Veiculos).FirstOrDefaultAsync();
        }
    }
}
