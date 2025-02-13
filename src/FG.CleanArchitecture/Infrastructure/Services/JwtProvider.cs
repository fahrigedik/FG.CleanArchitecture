using System.IdentityModel.Tokens.Jwt;
using Domain.Common;
using Domain.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Domain.Services;
using Infrastructure.Options;

namespace Infrastructure.Services;
public class JwtProvider(
    UserManager<AppUser> userManager,
    IOptions<JwtOptions> jwtOptions)
    : IJwtProvider
{
    public async Task<TokenResponse> CreateToken(AppUser appUser)
    {
        List<Claim> claims = new()
        {
            new Claim("Id", appUser.Id.ToString()),
            new Claim("Name", appUser.FirstName),
            new Claim("Email", appUser.Email ?? ""),
            new Claim("UserName", appUser.UserName ?? "")
        };

        DateTime expires = DateTime.UtcNow.AddMonths(1);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey));

        JwtSecurityToken jwtSecurityToken = new(
            issuer: jwtOptions.Value.Issuer,
            audience: jwtOptions.Value.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expires,
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512));

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(jwtSecurityToken);


        return new TokenResponse()
        {
            Expiration = expires,
            Token = token,
        };
    }
}
