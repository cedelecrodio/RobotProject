using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Services
{
    public class BaseMovementsService<TEntity> : IBaseMovementsService<TEntity> where TEntity : class
    {
        private readonly IBaseMovementsRepository<TEntity> repository;

        public BaseMovementsService(IBaseMovementsRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Contract(TEntity Object)
        {
            await repository.Contract(Object);
            return true;
        }

        public async Task<bool> Inclinate(TEntity Object)
        {
            await repository.Inclinate(Object);
            return true;
        }

        public async Task<bool> Rotate(TEntity Object)
        {
            var teste2 = await repository.Rotate(Object);
            return true;
        }

        public async Task<bool> ResetState(TEntity Object)
        {
            await repository.ResetState(Object);
            return true;
        }
    }
}
