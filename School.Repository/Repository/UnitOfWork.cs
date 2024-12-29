using School.Data.Contexts;
using School.Data.Entities.MainEntities;
using School.Repository.Interfaces;
using System.Collections;

namespace School.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolDbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        => await _context.SaveChangesAsync();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : GenericEntity
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var entityKey = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(entityKey))
            {
                var repositoryType = typeof(GenericRepository<>);
                var erpositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(entityKey, erpositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[entityKey];

        }
    }
}
