using AutoMapper;
using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers
{
    public class DtoToModelMappingRobot : Profile
    {
        public DtoToModelMappingRobot()
        {
            RobotMap();
        }

        private void RobotMap()
        {
            CreateMap<RobotDto, Robot>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.HeadInclination, opt => opt.MapFrom(x => x.HeadInclination))
                .ForMember(dest => dest.HeadRotation, opt => opt.MapFrom(x => x.HeadRotation))
                .ForMember(dest => dest.LeftElbow, opt => opt.MapFrom(x => x.LeftElbow))
                .ForMember(dest => dest.LeftFist, opt => opt.MapFrom(x => x.LeftFist))
                .ForMember(dest => dest.RightElbow, opt => opt.MapFrom(x => x.RightElbow))
                .ForMember(dest => dest.RightFist, opt => opt.MapFrom(x => x.RightFist));

        }
    }
}
