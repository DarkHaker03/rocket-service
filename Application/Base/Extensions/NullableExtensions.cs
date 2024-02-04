
using System.Collections;
using Microsoft.IdentityModel.Tokens;

namespace Application.Base.Extensions;

public static class NullableExtensions
{
	public static T ThrowIfNull<T>(this T nullableObject, string? message = null)
	{
		if (nullableObject == null)
		{
			throw new NullReferenceException(message ?? nameof(nullableObject));
		}

		return nullableObject;
	}
	
	public static T ThrowIfNullOrEmpty<T>(this T nullableObject, string? message = null) where T : IEnumerable<object>
	{
		if (nullableObject.IsNullOrEmpty())
		{
			throw new NullReferenceException(message ?? nameof(nullableObject));
		}

		return nullableObject;
	}
}
