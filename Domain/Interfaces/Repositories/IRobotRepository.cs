using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IRobotRepository : IBaseMovementsRepository<Robot>
    {
        Robot GetState();

    }
}
