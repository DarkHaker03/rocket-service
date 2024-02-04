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
			return Guid.Parse(Identity.Claims.FirstOrDefault(x => x.Type == UwUserClaimTypes.UserId)?.Value ?? throw new NullReferenceException("Claim userId was not found")); 
		}
	}
	public Guid EmployeeId
	{
		get
		{
			return Guid.Parse(Identity.Claims.FirstOrDefault(x => x.Type == UwUserClaimTypes.EmployeeId)?.Value ?? throw new NullReferenceException("Claim employeeId was not found"));
		}
	}

	public bool IsEmployee
	{
		get
		{
			return Identity.Claims.FirstOrDefault(x => x.Type == UwUserClaimTypes.EmployeeId) != null;
		}
	}
}
