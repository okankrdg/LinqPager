using LinqPager.Project.Models;
using System.Linq.Expressions;

namespace LinqPager.Project;

public static class PaginationExtension
{
    public static IQueryable<T> ToPagination<T>(this IQueryable<T> query, int page, int pageSize, string sortBy = "id", string sortType = "asc")
    {
        if (query == null) throw new ArgumentNullException("query");
        var sortedList = ApplyPagination(query, page, pageSize, sortBy, sortType);
        return sortedList.AsQueryable();
    }
    public static IQueryable<T> ToPagination<T>(this IQueryable<T> query, IPagination pagination)
    {
        if (query == null) throw new ArgumentNullException(nameof(query));
        if (pagination == null) throw new ArgumentNullException(nameof(pagination));

        var page = pagination.Page;
        var pageSize = pagination.PageSize;
        var sortBy = pagination.SortBy ?? "Id";
        var sortType = pagination.SortType ?? "asc";

        var sortedQuery = ApplyPagination(query, page, pageSize, sortBy, sortType);
        return sortedQuery.AsQueryable();
    }
    public static IEnumerable<T> ToPagination<T>(this IEnumerable<T> collection, int page, int pageSize, string sortBy = "id", string sortType = "asc")
    {
        if (collection == null) throw new ArgumentNullException("collection");

        var sortedCollection = ApplyPagination(collection, page, pageSize, sortBy, sortType);
        return sortedCollection;
    }

    public static List<T> ToPagination<T>(this List<T> list, int page, int pageSize, string sortBy = "id", string sortType = "asc")
    {
        if (list == null) throw new ArgumentNullException("list");

        var sortedList = ApplyPagination(list, page, pageSize, sortBy, sortType).ToList();
        return sortedList;
    }

    private static IEnumerable<T> ApplyPagination<T>(IEnumerable<T> collection, int page, int pageSize, string sortBy, string sortType)
    {
        if (page < 0 || pageSize < 0)
        {
            throw new ArgumentException("Page number and page size must be positive integers.");
        }
        var parameterExpression = Expression.Parameter(typeof(T));
        var lambda = Expression.Lambda<Func<T, object>>(
            Expression.Convert(Expression.Property(parameterExpression, sortBy), typeof(object)),
            new ParameterExpression[] { parameterExpression });

        var sortedCollection = sortType == "asc" ? collection.OrderBy(lambda.Compile()) : collection.OrderByDescending(lambda.Compile());
        var paginatedCollection = sortedCollection.Skip((Math.Max(page, 1) - 1) * pageSize).Take(pageSize);

        return paginatedCollection;
    }
}

