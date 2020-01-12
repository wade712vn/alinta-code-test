using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Alinta.Application.Queries.SearchCustomers;
using Alinta.Infrastructure.Ef;
using Xunit;

namespace Alinta.Application.UnitTests.Commands
{
    [Collection("QueryCollection")]
    public class SearchCustomersQueryHandlerTests
    {
        private readonly AlintaContext _context;

        public SearchCustomersQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task SearchCustomers_ByAdam_ReturnTwoCustomers()
        {
            var handler = new SearchCustomersQueryHandler(_context);
            var result = await handler.Handle(new SearchCustomersQuery("Adam"), CancellationToken.None);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task SearchCustomers_ByPeter_ReturnNone()
        {
            var handler = new SearchCustomersQueryHandler(_context);
            var result = await handler.Handle(new SearchCustomersQuery("Peter"), CancellationToken.None);

            Assert.Empty(result);
        }
    }
}
