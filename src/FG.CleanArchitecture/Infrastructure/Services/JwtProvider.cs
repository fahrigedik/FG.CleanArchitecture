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

namespace Infrastructure.Services;
public class JwtProvider(
    UserManager<AppUser> userManager,
    IOptions<JwtBearerOptions> jwtBearerOptions)
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

        var roles = await userManager.GetRolesAsync(appUser);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var signingKey = jwtBearerOptions.Value.TokenValidationParameters.IssuerSigningKey;
        var expiration = DateTime.UtcNow.AddHours(1);

        JwtSecurityToken securityToken = new(
            issuer: jwtBearerOptions.Value.TokenValidationParameters.ValidIssuer,
            audience: jwtBearerOptions.Value.TokenValidationParameters.ValidAudience,
            claims: claims,
            expires: expiration,
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
        );

        string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return new TokenResponse
        {
            Token = token,
            Expiration = expiration,
            RefreshToken = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
            RefreshTokenExpiration = DateTime.UtcNow.AddDays(7).ToString()
        };

    }
}
