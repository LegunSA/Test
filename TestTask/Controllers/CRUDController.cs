using Microsoft.AspNetCore.Mvc;
using TestTask.Model.Interfaces;
using TestTask.Service.Interfaces;
using TestTask.Data.Interfaces;
using AutoMapper;

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
      try
      {
        IEnumerable<Entity>? items = await _service.GetAllAsync();
        //TODO LS log
        return _mapper.Map<IEnumerable<Model>?>(items);
      }
      catch (Exception ex) 
      {
        return null;
      }
    }

    [HttpGet("get")]
    public async Task<Model?> Get([FromQuery] Guid id)
    {
      try
      {
        Entity? item = await _service.GetAsync(id);
        //TODO LS log
        return _mapper.Map<Model?>(item);
      }
      catch(Exception ex) { return null; }
    }

    [HttpPost("create")]
    public async Task<bool?> Create(Model item)
    {
      try
      {
        Entity entity = _mapper.Map<Entity>(item);
        bool? result = await _service.AddAsync(entity);
        //TODO LS log
        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    [HttpPut("edit")]
    public async Task<bool?> Update(Model item)
    {
      try
      {
        Entity entity = _mapper.Map<Entity>(item);

        bool? result = await _service.UpdateAsync(entity);
        //TODO LS log
        return result;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    [HttpDelete("delete")]
    public async Task<bool?> Delete([FromQuery] Guid id)
    {
      try
      {
        bool? result = await _service.DeleteAsync(id);
        //TODO LS log
        return result;
      }
      catch (Exception ex) 
      {
        return null;
      }
    }
  }
}
