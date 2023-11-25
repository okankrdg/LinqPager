using LinqPager.Test.Models;

namespace LinqPager.Test;

internal class PaginationTest : BaseTest
{

    [Test]
    public void ToPagination_WithPageSizeZero_ReturnsEmpty()
    {
        var mockQueryable = GetMockQueryable();
        int pageNumber = 1;
        int pageSize = 0;

        var result = mockQueryable.ToPagination(pageNumber, pageSize);

        Assert.IsEmpty(result);
    }

    [Test]
    public void ToPagination_WithNegativeValues_ThrowsException()
    {
        var mockQueryable = GetMockQueryable();
        int pageNumber = -1;
        int pageSize = -5;

        Assert.Throws<ArgumentException>(() => mockQueryable.ToPagination(pageNumber, pageSize));
    }

    [Test]
    public void ToPagination_WithOutOfRange_ReturnsEmpty()
    {
        var mockQueryable = GetMockQueryable();
        int pageNumber = 10;
        int pageSize = 5;

        var result = mockQueryable.ToPagination(pageNumber, pageSize);

        Assert.IsEmpty(result);
    }

    [Test]
    public void ToPagination_WithWhereClause_AppliesWhereBeforePagination()
    {
        var mockQueryable = GetMockQueryable();
        int pageNumber = 1;
        int pageSize = 2;

        var result = mockQueryable.Where(p => p.Price > 50 && p.Price < 301).ToPagination(pageNumber, pageSize);

        Assert.That(result.Count() == 1);
        Assert.That("Monitor" == result.First().Name);
    }
}

