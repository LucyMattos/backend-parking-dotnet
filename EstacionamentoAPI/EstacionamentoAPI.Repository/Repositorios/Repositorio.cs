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

        public virtual async Task<T> AddAsync(T entity, bool saveChanges = true)
        {
            var entryTrack = await _context.Set<T>().AddAsync(entity);
            if (saveChanges)
                await _context.SaveChangesAsync();
            return entryTrack.Entity;
        }
        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entity, bool saveChanges = true)
        {
            await _context.Set<T>().AddRangeAsync(entity.ToArray());
            if (saveChanges)
                await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task UpdateAsync(T entity, bool saveChanges = true)
        {
            _context.Set<T>().Update(entity);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<T> entity, bool saveChanges = true)
        {
            _context.Set<T>().UpdateRange(entity.ToArray());
            if (saveChanges)
                await _context.SaveChangesAsync();
        }
    }
}
