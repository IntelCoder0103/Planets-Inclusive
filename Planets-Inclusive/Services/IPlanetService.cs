using Planets_Inclusive.DTO;

namespace Planets_Inclusive.Services
{
    public interface IPlanetService
    {
        Task<IEnumerable<string>> GetAllNames();

        Task<PlanetDTO> GetByName(string name);
    }
}
