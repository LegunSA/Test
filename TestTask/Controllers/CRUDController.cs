using Microsoft.AspNetCore.Mvc;
using TestTask.Model.Interfaces;
using TestTask.Service.Interfaces;
using TestTask.Data.Interfaces;
using AutoMapper;
using TestTask.Data.Enums;

namespace TestTask.Controllers
{
  public class CRUDController<Model, Entity> : ControllerBase where Model : class, IModel where Entity : class, IEntity
  {
    protected IBaseSrvice<Entity> _service;
    protected readonly IMapper _mapper;

    public CRUDController(IBaseSrvice<Entity> service, IMapper mapper)
    {
      _service = service;
      _mapper = mapper;
    }

    [HttpGet("list")]
    public async Task<IEnumerable<Model>?> GetAll()
    {
      IEnumerable<Entity>? items = await _service.GetAllAsync();

      return _mapper.Map<IEnumerable<Model>?>(items);
    }

    [HttpGet("get/{id:Guid}")]
    public async Task<Model?> Get(Guid id)
    {
      Entity? item = await _service.GetAsync(id);

      return _mapper.Map<Model?>(item);
    }

    [HttpPost("create")]
    public async Task<bool> Create(Model item)
    {
      Entity entity = _mapper.Map<Entity>(item);

      return await _service.AddAsync(entity);
    }

    [HttpPut("edit")]
    public async Task<bool> Update(Model item)
    {
      Entity entity = _mapper.Map<Entity>(item);

      return await _service.UpdateAsync(entity);
    }

    [HttpDelete("delete/{id:Guid}")]
    public async Task<bool> Delete(Guid id)
    {
      return await _service.DeleteAsync(id);
    }
  }
}
