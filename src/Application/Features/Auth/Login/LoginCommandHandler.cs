using Domain.Common;
using Domain.Entities.Identity;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, TokenResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(UserManager<AppUser> userManager, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<TokenResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await _userManager.FindByEmailAsync(request.emailOrUsername) ??
                        await _userManager.FindByNameAsync(request.emailOrUsername);

        if (user is null)
        {
            throw new Exception("User not found");
        }

        var checkPassword = await _userManager.CheckPasswordAsync(user, request.password);

        if (!checkPassword)
        {
            throw new Exception("Password is wrong");
        }

        TokenResponse token = await _jwtProvider.CreateToken(user);

        return token;
    }
}