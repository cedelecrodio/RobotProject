using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IRobotService : IBaseMovementsService<Robot>
    {
        Robot GetState();


    }
}
