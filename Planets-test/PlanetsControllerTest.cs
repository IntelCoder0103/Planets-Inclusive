using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.Frameworks;
using Planets_Inclusive.Controllers;
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
    public class PlanetsControllerTest
    {
        private PlanetController _planetController;
        private Mock<IPlanetService> _mockPlanetService;
        
        public PlanetsControllerTest()
        {
            _mockPlanetService = new Mock<IPlanetService>();
            _planetController = new PlanetController(_mockPlanetService.Object);
        }

        [TestMethod]
        public async Task GetPlanetNames_ReturnsOkResult_WithPlanetNames()
        {
            var mockPlanets = new string[] { "planetA", "planetB" };

            _mockPlanetService.Setup(d => d.GetAllNames()).ReturnsAsync(mockPlanets);


            var result = await _planetController.GetPlanetNames();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(mockPlanets, (result as OkObjectResult).Value);
        }

        [TestMethod]
        public async Task GetPlanetByName_ReturnsOkResult_WithPlanet()
        {
            var mockPlanet = new PlanetDTO
            {
                Diameter = 1,
                DistanceFromSun = 1,
                Mass = 1,
                Name = "Earth",
                PictureURL = "earth.jpg"
            };

            _mockPlanetService.Setup(d => d.GetByName("Earth")).ReturnsAsync(mockPlanet);

            var result = await _planetController.GetPlanetByName("Earth");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(mockPlanet, (result as OkObjectResult).Value);
        }
    }
}
