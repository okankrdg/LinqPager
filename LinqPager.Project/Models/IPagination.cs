namespace LinqPager.Project.Models;

public interface IPagination
{
    int Page { get; set; }
    int PageSize { get; set; }
    string SortBy { get; set; }
    string SortType { get; set; }
}

