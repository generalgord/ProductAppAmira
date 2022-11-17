using AutoMapper;

using MediatR;

using ProductApp.Application.Common.DTO.Products;
using ProductApp.Application.Common.Repositories;
using ProductApp.Application.Common.Wrappers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Operations.Products.Queries.GetProductById
{
    public partial class GetProductByIdQuery : IRequest<ProductViewDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductViewDTO>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ProductViewDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);

            var vm = mapper.Map<ProductViewDTO>(product);

            return vm;
        }
    }
}
