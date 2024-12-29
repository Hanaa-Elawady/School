using School.Data.Entities.MainEntities;
using School.Repository.Specifications.SpecificationsBase;

namespace School.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : GenericEntity
    {
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingAsync();
        Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingWithSpecsAsync(ISpecifications<TEntity> specs);

        Task<TEntity> GetByIdAsync(Guid id);

    }
}
