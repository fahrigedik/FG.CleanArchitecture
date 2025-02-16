using Application.Features.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AuthController : BaseApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login( CancellationToken cancellationToken)
        {
            //var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(200, "Hello World");
        }
    }
}
