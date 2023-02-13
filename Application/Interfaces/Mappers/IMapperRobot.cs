using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Mappers
{
    public interface IMapperRobot
    {
        Robot MapperDtoToEntity(RobotDto robotDto);

        IEnumerable<RobotDto> MapperListRobotsDto(IEnumerable<Robot> robots);

        RobotDto MapperEntityToDto(Robot robot);
    }
}
