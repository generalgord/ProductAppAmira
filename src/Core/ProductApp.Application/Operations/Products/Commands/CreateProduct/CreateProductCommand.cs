using AutoMapper;

using MediatR;

using ProductApp.Application.Common.Mappings;
using ProductApp.Application.Common.Repositories;
using ProductApp.Application.Common.Wrappers;
using ProductApp.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Operations.Products.Commands.CreateProduct
{
    public partial class CreateProductCommand : IRequest<ServiceResponse<Guid>>, IMapFrom<Product>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);
            await productRepository.AddAsync(product);

            return new ServiceResponse<Guid>(product.Id);
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap();
        }
    }
}
