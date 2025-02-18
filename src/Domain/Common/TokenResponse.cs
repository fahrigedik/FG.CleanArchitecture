namespace Domain.Common;
public class TokenResponse
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
    public string RefreshToken { get; set; }
    public string RefreshTokenExpiration { get; set; }
}
