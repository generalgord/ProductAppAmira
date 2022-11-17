using ProductApp.Domain.Common;

namespace ProductApp.Application.Common.Repositories
{
    /// <summary>
    /// Accepts only BaseEntity derived classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepositoryAsync<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetPagedReponseAsync(int pageNumber, int pageSize);
        Task<IEnumerable<T>> GetPagedAdvancedReponseAsync(int pageNumber, int pageSize, string orderBy, string fields);
        Task<T> GetByIdAsync(Guid id);

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(T entity);
    }
}
