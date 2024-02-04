using System.Security.Claims;

namespace Application.Features.Auth.Services;

public class UserIdentity
{
	public UserIdentity(
		ClaimsPrincipal principal)
	{
		Identity =
			principal.Identity is ClaimsPrincipal authenticationIdentity
				? authenticationIdentity
				: principal.Identity!.IsAuthenticated
					? new ClaimsPrincipal(principal.Identities.First())
					: null;
	}

	public ClaimsPrincipal? Identity { get; set; }

	public Guid UserId
	{
		get 
		{ 
			return Guid.Parse(Identity.Claims.FirstOrDefault(x => x.Type == RUserClaimTypes.UserId)?.Value ?? throw new NullReferenceException("Claim userId was not found")); 
		}
	}
}
