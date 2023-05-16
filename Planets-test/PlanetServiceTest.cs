using AutoMapper;
using Microsoft.AspNetCore.Routing;
using Moq;
using Planets_Inclusive.Data;
using Planets_Inclusive.DTO;
using Planets_Inclusive.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets_test
{
    [TestClass]
    public class PlanetServiceTest
    {
        private PlanetService _planetService;
        private Mock<IPlanetDataAPI> _mockPlanetDataApi;
        private Mock<IMapper> _mockMapper;

        [TestInitialize]
        public void Setup()
        {
            _mockPlanetDataApi = new Mock<IPlanetDataAPI>();
            _mockMapper = new Mock<IMapper>();
            _planetService = new PlanetService(_mockPlanetDataApi.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task GetAllNames_ReturnsPlanetNames()
        {
            var result = await _planetService.GetAllNames();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<string>));
            Assert.AreEqual(PlanetService.PLANET_NAMES, result);
        }

        [TestMethod]
        public async Task GetByName_ReturnsMappedPlanetDTO()
        {
            var planetName = "Mars";
            var mockPlanetData = new PlanetDataDTO { Name = planetName, Radius = 1, Mass = 100 };
            var expectedDto = new PlanetDTO { Name = planetName, Diameter = 1, Mass = 100, PictureURL = "/images/planets/Marshero.jpg" };

            _mockPlanetDataApi.Setup(api => api.FetchPlanetData(planetName)).ReturnsAsync(mockPlanetData);
            _mockMapper.Setup(mapper => mapper.Map<PlanetDTO>(mockPlanetData)).Returns(expectedDto);

            var result = await _planetService.GetByName(planetName);

            Assert.AreEqual(expectedDto, result);
        }
    }
}
