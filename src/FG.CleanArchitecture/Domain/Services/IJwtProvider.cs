using Domain.Common;
using Domain.Identity;

namespace Domain.Services;
public interface IJwtProvider
{
    public Task<TokenResponse> CreateToken(AppUser appUser);
}
