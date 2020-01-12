using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alinta.Application.Commands.CreateCustomer;
using Alinta.Domain.Entities;
using Xunit;

namespace Alinta.WebApi.IntegrationTests
{
    public class CreateCustomerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {

        private readonly HttpClient _client;

        private readonly CustomWebApplicationFactory<Startup>
            _factory;

        public CreateCustomerTests(
            CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateCustomer_ValidCommand_ReturnsCreatedCustomer()
        {
            var command = new CreateCustomerCommand
            {
                FirstName = "Bruce",
                LastName = "Wayne",
                Dob = new DateTime(1970, 10, 20)
            };

            var requestContent = ApiHelper.GetRequestContent(command);
            var response = await _client.PostAsync($"/api/v1/Customers", requestContent);

            response.EnsureSuccessStatusCode();
            var responseContent = await ApiHelper.GetResponseContent<Customer>(response);

            Assert.IsType<Customer>(responseContent);
            Assert.Equal(command.FirstName, responseContent.FirstName);
            Assert.Equal(command.LastName, responseContent.LastName);
            Assert.Equal(command.Dob, responseContent.Dob);
        }

        [Fact]
        public async Task CreateCustomer_EmptyFirstName_ReturnsBadRequest()
        {
            var command = new CreateCustomerCommand
            {
                FirstName = "",
                LastName = "Wayne",
                Dob = new DateTime(1970, 10, 20)
            };

            var requestContent = ApiHelper.GetRequestContent(command);
            var response = await _client.PostAsync($"/api/v1/Customers", requestContent);

            
            var responseContent = await ApiHelper.GetResponseContent<IDictionary<string, List<string>>>(response);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            
            Assert.Contains("firstName", responseContent);
        }
    }
}
