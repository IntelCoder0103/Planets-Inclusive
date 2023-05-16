using AutoMapper;
using Planets_Inclusive.Data;
using Planets_Inclusive.DTO;

namespace Planets_Inclusive.Services
{
    public class PlanetService : IPlanetService
    {
        public static string[] PLANET_NAMES = { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" };

        private readonly IPlanetDataAPI _planetDataApi;
        private readonly IMapper _mapper;

        public PlanetService(IPlanetDataAPI planetDataApi, IMapper mapper)
        {
            _planetDataApi = planetDataApi;
            _mapper = mapper;
        }

        public async Task<IEnumerable<string>> GetAllNames()
        {
            return PLANET_NAMES;
        }

        public async Task<PlanetDTO> GetByName(string name)
        {
            var data = await this._planetDataApi.FetchPlanetData(name);

            var dto = _mapper.Map<PlanetDTO>(data);
            dto.Diameter = dto.Diameter * 69911; // Unit in Jupiters (1 Jupiter = 69911 km).
            dto.Mass = dto.Mass * 1.898 * 1e27; // Unit in Jupiters (1 Jupiter = 1.898 × 10^27 kg).
            dto.PictureURL = $"/images/planets/{name}hero.jpg";
            return dto;
        }
    }
}
