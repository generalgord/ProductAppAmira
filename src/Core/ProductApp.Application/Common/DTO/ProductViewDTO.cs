using ProductApp.Application.Common.Mappings;
using ProductApp.Domain.Entities;

namespace ProductApp.Application.Common.DTO
{
    public class ProductViewDTO : IMapFrom<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
