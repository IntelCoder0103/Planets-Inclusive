using Planets_Inclusive.DTO;

namespace Planets_Inclusive.Data
{
    public interface IPlanetDataAPI
    {
        public Task<PlanetDataDTO> FetchPlanetData(string planetName);
    }
}
