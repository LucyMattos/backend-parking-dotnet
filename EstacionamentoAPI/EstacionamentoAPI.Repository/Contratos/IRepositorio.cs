using EstacionamentoAPI.Domain.Entidades;

namespace EstacionamentoAPI.Repository.Contratos
{
    public interface IRepositorio<T> where T : Base
    {
        Task<T> AddAsync(T entity, bool saveChanges = true);
        Task UpdateAsync(T entity, bool saveChanges = true);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entity, bool saveChanges = true);
        Task UpdateRangeAsync(IEnumerable<T> entity, bool saveChanges = true);
    }
}