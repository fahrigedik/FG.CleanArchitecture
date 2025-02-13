using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        public readonly IMediator _mediator;
        protected BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
