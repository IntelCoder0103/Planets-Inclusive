using Planets_Inclusive.Data;
using Planets_Inclusive.DTO;

namespace Planets_Inclusive.DataAPI
{
    public class PlanetDataAPI : IPlanetDataAPI
    {
        protected static string PLANET_DATA_URL = "https://api.api-ninjas.com/v1/planets";
        protected static string DATA_API_KEY = "4M2274qQB+OyjpIOcrD8Dg==ULk97IWPkp8hmYAD";

        private readonly IHttpClientFactory _httpClientFactory;
        public PlanetDataAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PlanetDataDTO> FetchPlanetData(string planetName)
        {
            using var _httpClient = _httpClientFactory.CreateClient();

            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", DATA_API_KEY);

            using var response = await _httpClient.GetAsync($"{PLANET_DATA_URL}?name={planetName}");
            var planetData = await response.Content.ReadFromJsonAsync<IEnumerable<PlanetDataDTO>>();

            if (planetData == null || planetData.Count() <= 0)
                throw new Exception($"Planet data doesn't exist with the corresponding name: {planetName}");
            return planetData.First();
        }
    }
}
