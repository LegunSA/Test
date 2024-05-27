using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.Data.Interfaces;
using TestTask.Service.Interfaces;

namespace TestTask.Service
{
  public abstract class BaseService<Entity> : IBaseSrvice<Entity>
    where Entity : class, IEntity
  {
    protected readonly IMapper _mapper;
    protected readonly IRepository _repository;
    public BaseService(IMapper mapper, IRepository repository)
    {
      _mapper = mapper;
      _repository = repository;
    }
    public async Task<bool> AddAsync(Entity model)
    {
      await _repository.AddAsync(model);

      return await _repository.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
      Entity? element = await _repository.FirstOrDefaultAsync<Entity>(x => x.Id == id);

      if (element == null)
      {
        return false;
      }

      _repository.Remove(element);

      return await _repository.SaveChangesAsync();
    }

    public async Task<IEnumerable<Entity>> GetAllAsync()
    {
      try
      {
        return await _repository.Get<Entity>().ToListAsync() ?? Enumerable.Empty<Entity>();
      }
      catch (ArgumentNullException ex)
      {
        //TODO LS log
        return Enumerable.Empty<Entity>();
      }
    }

    public async Task<Entity?> GetAsync(Guid id)
    {
      return await _repository.FirstOrDefaultAsync<Entity>(x => x.Id == id);
    }

    public async Task<bool> UpdateAsync(Entity model)
    {
      _repository.Update(model);

      return await _repository.SaveChangesAsync();
    }
  }
}
