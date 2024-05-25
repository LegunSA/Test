using TestTask.Data.Interfaces;

namespace TestTask.Service.Interfaces
{
  public interface IBaseSrvice<Entity> where Entity : class, IEntity
  {
    public Task<Entity?> GetAsync(Guid id);
    public Task<bool> AddAsync(Entity entity);
    public Task<bool> UpdateAsync(Entity entity);
    public Task<bool> DeleteAsync(Guid id);
    public Task<IEnumerable<Entity>?> GetAllAsync();
  }
}
