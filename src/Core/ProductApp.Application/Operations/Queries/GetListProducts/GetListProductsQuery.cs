using AutoMapper;

using MediatR;
using ProductApp.Application.Common.DTO.Products;
using ProductApp.Application.Common.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Operations.Queries.GetListProducts
{
    public class GetListProductsQuery : IRequest<IList<ProductViewDTO>>
    {
        public class GetListProductsQueryHandler : IRequestHandler<GetListProductsQuery, IList<ProductViewDTO>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public GetListProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }

            public async Task<IList<ProductViewDTO>> Handle(GetListProductsQuery request, CancellationToken cancellationToken)
            {
                var list = await productRepository.GetAllAsync();

                var vm = mapper.Map<IList<ProductViewDTO>>(list);

                return vm;

            }
        }
    }
}
