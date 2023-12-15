using HttpClassLibrary;
using System.Net;
using HttpClassLibrary;
namespace HttpTaskTests
{
    public class ConsumerTests
    {
        [Fact]
        public async Task GetMyName_ReturnsCorrectName()
        {
            // Arrange
            var expectedName = "Your Name"; // Replace with expected name
            var expectedUrl = "http://localhost:8888/MyName";

            var httpClient = new HttpClient(handler);
            var myClient = new HttpClient(httpClient);

            // Act
            var result = await myClient.GetMyName();

            // Assert
            Assert.Equal(expectedName, result);
        }

        [Fact]
        public async Task GetInformation_ReturnsStatusCode100()
        {
            // Arrange
            var expectedUrl = "http://localhost:8888/Information";
            var expectedStatusCode = HttpStatusCode.Continue;
            var httpClient = new HttpClient(handler);
            var myClient = new HttpClient(httpClient);

            // Act
            var response = await myClient.GetInformation();

            // Assert
            Assert.Equal(expectedStatusCode, response.StatusCode);
        }

        // Write similar tests for other client-side methods interacting with different endpoints
    }

}