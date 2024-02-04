using Microsoft.IdentityModel.Tokens;

namespace Application.Features.Auth.Options;

public class AuthOptions
{
    public const string Key = "Auth";

    public required string SecretKeyBase64 { get; set; }

    public required string Issuer { get; set; }

    public required string Audience { get; set; }

    public required int ExpiresIn { get; set; }

    public SymmetricSecurityKey GetSecretKey() 
    {
		return new SymmetricSecurityKey(Convert.FromBase64String(SecretKeyBase64));
    }
}

