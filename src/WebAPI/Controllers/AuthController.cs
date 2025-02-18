using Application.Features.Auth.Login;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly SignInManager<AppUser> _signInManager;
        public AuthController(IMediator mediator, SignInManager<AppUser> signInManager) : base(mediator)
        {
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand request , CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(200, response);
        }


        //Please remove this method after you have created an example user
        [HttpPost("create-example-user")]
        public async Task<IActionResult> Register(CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                UserName = "exampleuser",
                Email = "exampleuser@example.com",
                FirstName = "Example",
                LastName = "User"
            };

            var result = await _signInManager.UserManager.CreateAsync(user, "ExamplePassword123!");

            if (result.Succeeded)
            {
                return StatusCode(200, "User created successfully");
            }

            return StatusCode(400, "Error creating user");

       }
    }
}
