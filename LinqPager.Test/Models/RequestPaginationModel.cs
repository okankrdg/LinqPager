using LinqPager.Project.Models;

namespace LinqPager.Test.Models;

public class RequestPaginationModel : IPagination
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string SortBy { get; set; } = "id";
    public string SortType { get; set; } = "asc";
}

