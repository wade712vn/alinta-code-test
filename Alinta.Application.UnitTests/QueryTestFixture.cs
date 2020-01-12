using System;
using System.Collections.Generic;
using System.Text;
using Alinta.Domain.Entities;
using Alinta.Infrastructure.Ef;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Alinta.Application.UnitTests
{
    public class QueryTestFixture : IDisposable
    {
        public AlintaContext Context { get; private set; }

        public QueryTestFixture()
        {
            var options = new DbContextOptionsBuilder<AlintaContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            Context = new AlintaContext(options);

            Context.Database.EnsureCreated();

            Context.Customers.AddRange(new[] {
                new Customer("Adam", "Levine", new DateTime(1990, 1, 1)),
                new Customer("Sean", "Bean", new DateTime(1970, 11, 11)),
                new Customer("Adam", "Lambert", new DateTime(1980, 5, 5)),
            });

            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
