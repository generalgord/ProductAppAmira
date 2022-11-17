using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ProductApp.Application.Common.Wrappers;
using ProductApp.Application.Operations.Products.Commands.CreateProduct;
using ProductApp.Application.Operations.Products.Queries.GetListProducts;
using ProductApp.Application.Operations.Products.Queries.GetProductById;

namespace ProductApp.WebApi.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        public ProductsController(IHttpContextAccessor contextAccessor) : base(contextAccessor)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetListProductsQuery();
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Guid>>> Post(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery() { Id = id };
            return Ok(await Mediator.Send(query));
        }

    }
}
