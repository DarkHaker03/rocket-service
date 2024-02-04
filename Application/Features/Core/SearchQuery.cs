using System.Collections;
using System.Linq.Expressions;

namespace Application.Features.Host;

public class SearchQueryContainer<T, TValue>(
    Expression<Func<T, TValue>> property,
    string? searchText,
    IQueryable<T> queryable)
{
    private IQueryable<T> _query = queryable;
    private IQueryable<T> _newQuery = queryable.Where(BuildSearchExpression(property, searchText));

    /// <summary>
    /// Завершает цепочку очереди поиска
    /// см. FilterSearch
    /// </summary>
    public IQueryable<T> Search(Expression<Func<T, TValue>> property, string? searchText)
    {
        UnionSearch(property, searchText);
        return _newQuery;
    }

    /// <summary>
    /// Добавляет фильтр в очередь поиска
    /// При вызове Search будут найдены все элементы по филтьрам из "орчереди"
    /// Пример: 10 товаров с именем example и 3 товара с артиклем example = 13 товаров
    /// </summary>
    public SearchQueryContainer<T, TValue> UnionSearch(Expression<Func<T, TValue>> property, string? searchText)
    {
        var searchExpression = BuildSearchExpression(property, searchText);
        this.Append(searchExpression);
        return this;
    }



    public static Expression<Func<T, bool>> BuildSearchExpression<T, TValue>(Expression<Func<T, TValue>> property,
        string? searchText)
    {
        if (string.IsNullOrEmpty(searchText))
        {
            return property => true;
        }

        MethodCallExpression toStringExpression = null;
        var parameter = property.Parameters.Single();
        var propertyBody = property.Body;

        if (propertyBody.Type != typeof(string))
        {
            toStringExpression =
                Expression.Call(propertyBody, typeof(TValue).GetMethod("ToString", System.Type.EmptyTypes));
        }

        var toLowerMethod = typeof(string).GetMethod("ToLower", System.Type.EmptyTypes);
        var toLowerExpression =
            Expression.Call(toStringExpression == null ? propertyBody : toStringExpression, toLowerMethod);
        var searchMethod = searchText.Length > 3
            ? typeof(string).GetMethod("Contains", new[] { typeof(string) })
            : typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
        ;
        var searchValue = Expression.Constant(searchText.ToLower(), typeof(string));
        var searchExpression = Expression.Call(toLowerExpression, searchMethod, searchValue);
        return Expression.Lambda<Func<T, bool>>(searchExpression, parameter);
    }

    private void Append(Expression<Func<T, bool>> expression)
    {
        _newQuery = _newQuery.Union(_query.Where(expression)).Distinct();
    }
}