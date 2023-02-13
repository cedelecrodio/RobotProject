using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServiceRobot
    {
        RobotDto GetState();
        Task<bool> Contract(int member, int contractLevel);
        Task<bool> Inclinate(int member, int inclinate);
        Task<bool> Rotate(int member, int rotateLevel);
    }
}
