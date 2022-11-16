using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;

        protected ISender Mediator = null!;

        private ISender _mediator = null!;
        public ApiControllerBase(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            Mediator = _mediator ??= contextAccessor.HttpContext?.RequestServices.GetRequiredService<ISender>();
        }

    }
}
