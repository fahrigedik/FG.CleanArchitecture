using Domain.Common;
using Domain.Entities.Identity;

namespace Domain.Services;
public interface IJwtProvider
{
    public Task<TokenResponse> CreateToken(AppUser appUser);
}
