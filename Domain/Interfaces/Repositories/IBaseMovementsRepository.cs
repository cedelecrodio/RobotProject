namespace Domain.Interfaces.Repositories
{
    public interface IBaseMovementsRepository<TEntity> where TEntity : class
    {
        Task<bool> Inclinate(TEntity Object);

        Task<bool> Contract(TEntity Object);

        Task<bool> Rotate(TEntity Object);

        Task<bool> ResetState(TEntity Object);
    }
}
