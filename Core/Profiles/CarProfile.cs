using AutoMapper;
using Domain.Entities;

namespace Core.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarProfile, Car>();
            CreateMap<Car, CarProfile>();
        }
    }
}
