using Application.Dtos;
using Application.Interfaces.Mappers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class MapperRobot : IMapperRobot
    {
        public Robot MapperDtoToEntity(RobotDto robotDto)
        {
            var robot = new Robot()
            {
                Id = robotDto.Id
               ,
                HeadRotation = robotDto.HeadRotation
               ,
                HeadInclination = robotDto.HeadInclination
               ,
                LeftElbow = robotDto.LeftElbow
               ,
                LeftFist = robotDto.LeftFist
               ,
                RightElbow = robotDto.RightElbow
               ,
                RightFist = robotDto.RightFist
            };

            return robot;
        }

        public RobotDto MapperEntityToDto(Robot robot)
        {
            RobotDto robotDto = new RobotDto()
            {
                Id = robot.Id
               ,
                HeadRotation = robot.HeadRotation
               ,
                HeadInclination = robot.HeadInclination
               ,
                LeftElbow = robot.LeftElbow
               ,
                LeftFist = robot.LeftFist
               ,
                RightElbow = robot.RightElbow
               ,
                RightFist = robot.RightFist
            };

            return robotDto;
        }

        public IEnumerable<RobotDto> MapperListRobotsDto(IEnumerable<Robot> robots)
        {
            var dto = robots.Select(r => new RobotDto() { Id = r.Id
                                                        , HeadRotation = r.HeadRotation
                                                        , HeadInclination = r.HeadInclination
                                                        , LeftElbow = r.LeftElbow
                                                        , LeftFist = r.LeftFist
                                                        , RightElbow = r.RightElbow
                                                        , RightFist = r.RightFist });
            return dto;
        }
    }
}
