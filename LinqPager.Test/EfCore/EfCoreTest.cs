namespace LinqPager.Test.EfCore;

[TestFixture]
public class EfCoreTest : EfCoreBaseTest
{
    [Test]
    public void PaginationExtension_NegativePageSize_ThrowsException()
    {
        // Arrange
        using (var context = new InMemoryContext(_options))
        {
            var query = context.Products.AsQueryable();
            int page = 1;
            int pageSize = -2;

            Assert.Throws<ArgumentException>(() => query.ToPagination(page, pageSize));
        }
    }

    [Test]
    public void PaginationExtension_NegativePageNumber_ThrowsException()
    {
        // Arrange
        using (var context = new InMemoryContext(_options))
        {
            var query = context.Products.AsQueryable();
            int page = -1;
            int pageSize = 2;

            Assert.Throws<ArgumentException>(() => query.ToPagination(page, pageSize));
        }
    }

    [Test]
    public void PaginationExtension_InvalidSortBy_ThrowsException()
    {
        // Arrange
        using (var context = new InMemoryContext(_options))
        {
            var query = context.Products.AsQueryable();
            int page = 1;
            int pageSize = 2;
            string invalidSortBy = "Banu";

            Assert.Throws<ArgumentException>(() => query.ToPagination(page, pageSize, invalidSortBy));
        }
    }

    [Test]
    public void PaginationExtension_WhereClauseAndPagination()
    {
        // Arrange
        using (var context = new InMemoryContext(_options))
        {
            var query = context.Products.AsQueryable();
            int page = 1;
            int pageSize = 2;

            var result = query.Where(p => p.Price > 50 && p.Price < 301).ToPagination(page, pageSize);

            Assert.That(1 == result.Count());
        }
    }
}

