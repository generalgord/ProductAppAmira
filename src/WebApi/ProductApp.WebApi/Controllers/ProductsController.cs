using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ProductApp.Application.Operations.Queries.GetListProducts;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

    }
}
