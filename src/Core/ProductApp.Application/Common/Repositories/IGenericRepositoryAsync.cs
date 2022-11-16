using ProductApp.Domain.Common;

namespace ProductApp.Application.Common.Repositories
{
    /// <summary>
    /// Accepts only BaseEntity derived classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepositoryAsync<T> where T : BaseEntity
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
    }
}
