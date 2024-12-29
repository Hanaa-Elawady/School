using Microsoft.EntityFrameworkCore;
using School.Data.Contexts;
using School.Data.Entities.MainEntities;
using School.Repository.Interfaces;
using School.Repository.Specifications.SpecificationsBase;

namespace School.Repository.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : GenericEntity
    {
        private readonly SchoolDbContext _context;

        public GenericRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        => await _context.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity)
           => _context.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity)
        => _context.Set<TEntity>().Remove(entity);

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
           => await _context.Set<TEntity>().ToListAsync();
        public async Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingAsync()
           => await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        public async Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingWithSpecsAsync(ISpecifications<TEntity> specs)
        => await SpecificationsEvaluator<TEntity>.GetQuery(_context.Set<TEntity>(), specs).ToListAsync();
        public async Task<TEntity> GetByIdAsync(Guid id)
        => await _context.Set<TEntity>().FindAsync(id);
       

    }
}
