namespace LinqPager.Test;

internal class SortingTest : BaseTest
{
    [Test]
    public void ToPagination_WithInvalidSortField_ThrowsException()
    {
        // Arrange
        var mockQueryable = GetMockQueryable();
        int pageNumber = 1;
        int pageSize = 2;
        string invalidSortField = "InvalidField";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => mockQueryable.ToPagination(pageNumber, pageSize, invalidSortField));
    }
    [Test]
    public void ToPagination_WithCamelCaseSortBy_SortsCorrectly()
    {
        // Arrange
        var mockQueryable = GetMockQueryable();
        int pageNumber = 1;
        int pageSize = 2;
        string camelCaseSortBy = "price";

        // Act
        var result = mockQueryable.ToPagination(new RequestPaginationModel
        {
            Page = pageNumber,
            PageSize = pageSize,
            SortBy = camelCaseSortBy,
            SortType = "asc"
        });

        // Assert
        Assert.That(20 == result.First().Price);
    }

    [Test]
    public void ToPagination_WithPascalCaseSortBy_SortsCorrectly()
    {
        // Arrange
        var mockQueryable = GetMockQueryable();
        int pageNumber = 1;
        int pageSize = 2;
        string pascalCaseSortBy = "Price"; // PascalCase olarak alan adı

        // Act
        var result = mockQueryable.ToPagination(new RequestPaginationModel
        {
            Page = pageNumber,
            PageSize = pageSize,
            SortBy = pascalCaseSortBy,
            SortType = "desc"
        });

        // Assert
        Assert.AreEqual(1200, result.First().Price); // En yüksek fiyat Laptop'un fiyatı (1200)
    }
}

