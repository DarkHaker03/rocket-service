using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.Features.Auth;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class UwAuthorizeAttribute : Attribute
{
	public readonly string[] RequiredClaims;
	
	public UwAuthorizeAttribute(string role)
	{
		RequiredClaims = new[] { role };
	}

	public UwAuthorizeAttribute(string[] roles)
	{
		RequiredClaims = roles;
	}
}



