using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpTaskTests
{
    public class HttpConsumerTests
    {
        private readonly HttpClient _client;

        public HttpConsumerTests(TestServerFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task GetMyName_ReturnsCorrectName()
        {
            // Arrange
            var expectedName = "Your Name"; // Replace with expected name

            // Act
            var response = await _client.GetAsync("/MyName");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expectedName, content);
        }

        [Fact]
        public async Task Information_ReturnsStatusCode100()
        {
            var response = await _client.GetAsync("/Information");
            Assert.Equal(HttpStatusCode.Continue, response.StatusCode); // HTTP 100
        }

        [Fact]
        public async Task Success_ReturnsStatusCode200()
        {
            var response = await _client.GetAsync("/Success");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode); // HTTP 200
        }

        [Fact]
        public async Task Redirection_ReturnsStatusCode300()
        {
            var response = await _client.GetAsync("/Redirection");
            Assert.Equal(HttpStatusCode.Ambiguous, response.StatusCode); // HTTP 300
        }

        [Fact]
        public async Task ClientError_ReturnsStatusCode400()
        {
            var response = await _client.GetAsync("/ClientError");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode); // HTTP 400
        }

        [Fact]
        public async Task ServerError_ReturnsStatusCode500()
        {
            var response = await _client.GetAsync("/ServerError");
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode); // HTTP 500
        }

        [Fact]
        public async Task GetMyNameByHeader_ReturnsNameInHeader()
        {
            var response = await _client.GetAsync("/MyNameByHeader");
            Assert.True(response.Headers.TryGetValues("X-MyName", out var values));
            Assert.Equal("Your Name", Assert.Single(values));
        }

        [Fact]
        public async Task MyNameByCookies_ReturnsNameInCookies()
        {
            var response = await _client.GetAsync("/MyNameByCookies");
            Assert.True(response.Headers.TryGetValues("Set-Cookie", out var values));
            Assert.Contains("MyName=Your Name", values);
        }
    }

    public class TestServerFixture : IDisposable
    {
        public HttpClient Client { get; }

        public TestServerFixture()
        {
            var server = new Microsoft.AspNetCore.TestHost.TestServer(new Microsoft.AspNetCore.Hosting.WebHostBuilder()
                .UseStartup<Startup>());

            Client = server.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }

}
}
