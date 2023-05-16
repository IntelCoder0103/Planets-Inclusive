using Microsoft.AspNetCore.Routing;
using Moq;
using Planets_Inclusive.DataAPI;
using Planets_Inclusive.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Moq.Protected;

namespace Planets_test
{
    [TestClass]
    public class PlanetDataApiTest
    {
        private PlanetDataAPI _planetDataAPI;
        private Mock<HttpClient> _mockHttpClient;
        private Mock<HttpMessageHandler> _mockMessageHandler;

        [TestInitialize]
        public void Setup()
        {
            _mockMessageHandler = new Mock<HttpMessageHandler>();
            _mockHttpClient = new Mock<HttpClient>(_mockMessageHandler.Object);

            // Inject the mock HttpClient into the PlanetDataAPI instance
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(_mockHttpClient.Object);
            _planetDataAPI = new PlanetDataAPI(httpClientFactoryMock.Object);

        }
        [TestMethod]
        public async Task FetchPlanetData_ReturnsPlanetDataDTO()
        {
            var planetName = "Mars";
            var expectedPlanetData = new PlanetDataDTO { Name = planetName, Radius = 6.779, Mass = 0.64171 };
            var expectedPlanetDataList = new List<PlanetDataDTO> { expectedPlanetData };

            _mockMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = JsonContent.Create(expectedPlanetDataList)
            });

            var result = await _planetDataAPI.FetchPlanetData(planetName);

            Assert.AreEqual(expectedPlanetData.Name, result.Name);
            Assert.AreEqual(expectedPlanetData.Radius, result.Radius);
            Assert.AreEqual(expectedPlanetData.Mass, result.Mass);
            Assert.AreEqual(expectedPlanetData.Period, result.Period);
            Assert.AreEqual(expectedPlanetData.Temperature, result.Temperature);
            Assert.AreEqual(expectedPlanetData.distance_light_year, result.distance_light_year);

        }

        [TestMethod]
        public void FetchPlanetData_ThrowsException_WhenNoDataFound()
        {
            var planetName = "InvalidPlanet";
            var emptyPlanetDataList = Enumerable.Empty<PlanetDataDTO>();

            _mockMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = JsonContent.Create(emptyPlanetDataList)
            });

            Assert.ThrowsExceptionAsync<Exception>(async () => await _planetDataAPI.FetchPlanetData(planetName));
        }
    }
}
