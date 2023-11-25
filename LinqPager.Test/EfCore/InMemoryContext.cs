using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPager.Test.EfCore
    ;
public class InMemoryContext : DbContext
{
    public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}

