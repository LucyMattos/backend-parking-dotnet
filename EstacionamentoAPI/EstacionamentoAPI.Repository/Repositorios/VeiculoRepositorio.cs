using EstacionamentoAPI.Domain.Entidades;
using EstacionamentoAPI.Repository.Contexto;
using EstacionamentoAPI.Repository.Contratos;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Repository.Repositorios
{
    public class VeiculoRepositorio : Repositorio<Veiculo>, IVeculoRepositorio
    {
        private readonly EstacionamentoContext _context;
        public VeiculoRepositorio(EstacionamentoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Veiculo>> GetAll()
        {
            return await _context.Veiculos.Where(e => !e.Excluido).Include(e => e.Empresa).ToListAsync();
        }

        public async Task<Veiculo> GetAsync(int id, int empresaId)
        {
            return await _context.Veiculos.Where(v => v.Id == id  && v.EmpresaId == empresaId && !v.Excluido).FirstOrDefaultAsync();
        }
    }
}
