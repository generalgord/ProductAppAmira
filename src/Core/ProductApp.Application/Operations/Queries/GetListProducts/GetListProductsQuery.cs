using MediatR;

using ProductApp.Application.Common.DTO;
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

            public GetListProductsQueryHandler(IProductRepository productRepository)
            {
                this.productRepository = productRepository;
            }

            public async Task<IList<ProductViewDTO>> Handle(GetListProductsQuery request, CancellationToken cancellationToken)
            {
                var list = await productRepository.GetAllAsync();

                return new List<ProductViewDTO>() { };

            }
        }
    }
}
