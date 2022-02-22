using AutoMapper;
using SampleApi.Models;

namespace SampleApi.Mapper
{
    public class ParkyMappings:Profile
    {
        public ParkyMappings()
        {
            CreateMap<NationalPark, NationalParkDTO>().ReverseMap();
            CreateMap<Users, UsersDTO>().ReverseMap();
            CreateMap<Trail, TrialDTO>().ReverseMap();
            CreateMap<Trail, TrailRequestDTO>().ReverseMap();
            CreateMap<Trail, TrailUpdateDTO>().ReverseMap();
        }
    }
}
