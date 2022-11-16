using ProductApp.Domain.Entities;

namespace ProductApp.Application.Common.Repositories
{
    public interface IProductRepository : IGenericRepositoryAsync<Product> { }
}
