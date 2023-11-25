using LinqPager.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPager.Test;

internal abstract class BaseTest
{
    public IQueryable<Product> GetMockQueryable()
    {
        var mockData = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200 },
            new Product { Id = 2, Name = "Mouse", Price = 20 },
            new Product { Id = 3, Name = "Keyboard", Price = 50 },
            new Product { Id = 4, Name = "Monitor", Price = 300 }
        };

        return mockData.AsQueryable();
    }
}

