using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    internal class ModelToDtoMappingRobot : Profile
    {
        public ModelToDtoMappingRobot()
        {
            RobotDtoMap();
        }


        private void RobotDtoMap()
        {
            CreateMap<Robot, RobotDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.HeadRotation, opt => opt.MapFrom(x => x.HeadRotation))
                .ForMember(dest => dest.HeadInclination, opt => opt.MapFrom(x => x.HeadInclination))
                .ForMember(dest => dest.LeftElbow, opt => opt.MapFrom(x => x.LeftElbow))
                .ForMember(dest => dest.LeftFist, opt => opt.MapFrom(x => x.LeftFist))
                .ForMember(dest => dest.RightElbow, opt => opt.MapFrom(x => x.RightElbow))
                .ForMember(dest => dest.RightFist, opt => opt.MapFrom(x => x.RightFist));
        }
    }
}
