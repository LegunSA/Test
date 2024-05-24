using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.Data.Interfaces;
using TestTask.Model.Interfaces;
using TestTask.Service.Interfaces;

namespace TestTask.Service
{
  public abstract class BaseService<Enity, Model> : IBaseSrvice<Model>
    where Enity : class, IEntity
    where Model : class, IModel
  {
    protected readonly IMapper _mapper;
    protected readonly IRepository _repository;
    public BaseService(IMapper mapper, IRepository repository)
    {
      _mapper = mapper;
      _repository = repository;
    }
    public async Task<bool> AddAsync(Model model)
    {
      await _repository.AddAsync(_mapper.Map<Enity>(model));

      return await _repository.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
      Enity? element = await _repository.FirstOrDefaultAsync<Enity>(x => x.Id == id);

      if (element == null)
      {
        return false;
      }

      _repository.Remove(element);

      return await _repository.SaveChangesAsync();
    }

    public async Task<IEnumerable<Model>> GetAllAsync()
    {
      return _mapper.Map<IEnumerable<Model>>(await _repository.Get<Enity>().ToListAsync());
    }

    public async Task<Model> GetAsync(Guid id)
    {
      return _mapper.Map<Model>(await _repository.FirstOrDefaultAsync<Enity>(x => x.Id == id));
    }

    public async Task<bool> UpdateAsync(Model model)
    {
      _repository.Update(_mapper.Map<Enity>(model));

      return await _repository.SaveChangesAsync();
    }
  }
}
