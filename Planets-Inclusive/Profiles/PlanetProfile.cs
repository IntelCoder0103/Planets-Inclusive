using AutoMapper;
using Planets_Inclusive.DTO;

namespace Planets_Inclusive.Profiles
{
    public class PlanetProfile: Profile
    {
        public PlanetProfile()
        {
            CreateMap<PlanetDataDTO, PlanetDTO>()
                .ForMember(x => x.Diameter, builder => builder.MapFrom(x => x.Radius))
                .ForMember(x => x.DistanceFromSun, builder => builder.MapFrom(x => x.distance_light_year));
        }
    }
}
