using AutoMapper;
using Domain.Entities;

namespace Core.Profiles
{
    public class MotorbikeProfile : Profile
    {
        public MotorbikeProfile()
        {
            CreateMap<MotorbikeProfile, Motorbike>();
            CreateMap<Motorbike, MotorbikeProfile>();
        }
    }
}
