using System.Linq.Expressions;

namespace TestTask.Data.Interfaces
{
  public interface IRepository
  {
    public IQueryable<TEntity> Get<TEntity>() where TEntity : class, IEntity;
    public Task<TEntity?> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> condition) where TEntity : class, IEntity;
    public Task AddAsync<TEntity>(TEntity entity) where TEntity : class, IEntity;
    public void Update<TEntity>(TEntity entity) where TEntity : class, IEntity;
    public void Remove<TEntity>(TEntity entity) where TEntity : class, IEntity;
    public Task<bool> SaveChangesAsync();
  }
}
