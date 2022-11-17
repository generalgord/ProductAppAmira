namespace ProductApp.Application.Common.DTO.Products
{
    public class ProductCreateDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
