using Application.Base.Interfaces;
using System.Linq.Expressions;
using Application.Features.Host;
using Microsoft.IdentityModel.Tokens;

namespace Application.Base.Extensions;

public static class FiltersExtensions
{
	public static IQueryable<T> ApplyCollectionFilter<T>(this IQueryable<T> collection, ICollectionFilter? filter)
	{
		if (filter == null)
		{
			return collection;
		}

		return collection.Skip(filter.Skip ?? 0).Take(filter.Take ?? 100);
	}

	/// <summary>
	/// Filter if nullable object is not null
	/// </summary>
	public static IQueryable<T> FilterIfNotNull<T,O>(this IQueryable<T> collection, Expression<Func<T,bool>> filter, O? nullableObject)
	{
		if (nullableObject == null)
		{
			return collection;
		}

		return collection.Where(filter);
	}
	
	public static IQueryable<T> FilterIfTrue<T>(this IQueryable<T> collection, Expression<Func<T,bool>> filter, bool condition)
	{
		if (!condition)
		{
			return collection;
		}

		return collection.Where(filter);
	}
	
	/// <summary>
	/// Начинает цепочку параллельнного поиска
	/// </summary>
	public static  SearchQueryContainer<T, TValue> UnionSearch<T, TValue>(this IQueryable<T> source, Expression<Func<T, TValue>> property, string? searchText)
	{
			return new SearchQueryContainer<T, TValue>(property, searchText, source);
	}
	
	/// <summary>
	///  Поиск
	/// </summary>
	public static  IQueryable<T> Search<T, TValue>(this IQueryable<T> source, Expression<Func<T, TValue>> property, string? searchText)
	{
		return new SearchQueryContainer<T, TValue>(property, searchText, source).Search(property, searchText);
	}
	
	
}
