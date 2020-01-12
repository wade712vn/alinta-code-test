using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alinta.Application.Commands.CreateCustomer;
using Alinta.Application.Commands.DeleteCustomer;
using Alinta.Infrastructure.Ef;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Alinta.WebApi.IntegrationTests
{
    public class DeleteCustomerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        private readonly CustomWebApplicationFactory<Startup>
            _factory;

        public DeleteCustomerTests(
            CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task DeleteCustomer_ValidId_ReturnsSuccess()
        {
                var response = await _client.DeleteAsync($"/api/v1/Customers/1");

                response.EnsureSuccessStatusCode();
        }
    }
}
