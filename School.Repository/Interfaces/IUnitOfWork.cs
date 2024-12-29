using School.Data.Entities.MainEntities;

namespace School.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : GenericEntity;
        Task<int> CompleteAsync();
    }
}
