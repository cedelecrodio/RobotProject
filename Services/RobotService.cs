using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Services
{
    public class RobotService : BaseMovementsService<Robot>, IRobotService
    {
        private readonly IRobotRepository robotRepository;

        public RobotService(IRobotRepository robotRepository) : base(robotRepository)
        {
            this.robotRepository = robotRepository;
        }

        public Robot GetState()
        {
            var RobotState = robotRepository.GetState();
            return RobotState;
        }
    }
}
