using Microsoft.EntityFrameworkCore;

namespace LinqPager.Test.EfCore;

public class EfCoreBaseTest
{
    public DbContextOptions<InMemoryContext> _options;

    [SetUp]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<InMemoryContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using (var context = new InMemoryContext(_options))
        {
            var mockData = new[]
            {
                    new Product { Id = 1, Name = "Laptop", Price = 1200, Owner = "Banu" },
                    new Product { Id = 2, Name = "Mouse", Price = 20 },
                    new Product { Id = 3, Name = "Keyboard", Price = 50 },
                    new Product { Id = 4, Name = "Monitor", Price = 300 }
                };
            context.Products.AddRange(mockData);
            context.SaveChanges();
        }
    }
}

