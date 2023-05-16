using System.Diagnostics.CodeAnalysis;

namespace Planets_Inclusive.DTO
{
    public class PlanetDTO
    {
        public string Name { get; set; }
        public double Diameter { get; set; }
        public double Mass { get; set; }
        public double DistanceFromSun { get; set; }
        public string? PictureURL { get; set; }
    }

    public class PlanetDataDTO
    {
        public string Name { get; set; }
        public double Mass { get; set; }
        public double Radius { get; set; }
        public double Period { get; set; }
        public double Temperature { get; set; }
        public double distance_light_year { get; set; }

    }
}
