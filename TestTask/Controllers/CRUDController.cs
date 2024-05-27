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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IEnumerable<Model>?> GetAll()
    {
      try
      {
        return _mapper.Map<IEnumerable<Model>>(await _service.GetAllAsync());
      }
      catch (ArgumentNullException)
      {
        HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        return null;
      }
      catch (Exception ex)
      {
        //TODO LS log
        HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        return null;
      }
    }

    [HttpGet("get")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<Model?> Get([FromQuery] Guid id)
    {
      try
      {
        Entity? item = await _service.GetAsync(id);
        return _mapper.Map<Model?>(item);
      }
      catch (ArgumentNullException)
      {
        HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        return null;
      }
      catch (Exception ex)
      {
        //TODO LS log
        HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        return null;
      }
    }

    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<bool?> Create(Model item)
    {
      try
      {
        Entity entity = _mapper.Map<Entity>(item);
        bool result = await _service.AddAsync(entity);

        HttpContext.Response.StatusCode = result
           ? StatusCodes.Status201Created
           : StatusCodes.Status500InternalServerError;

        return result;
      }
      catch (Exception ex)
      {
        HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        return null;
      }
    }

    [HttpPut("edit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<bool> Update(Model item)
    {
      try
      {
        Entity entity = _mapper.Map<Entity>(item);

        bool result = await _service.UpdateAsync(entity);
        HttpContext.Response.StatusCode = result 
          ? StatusCodes.Status200OK
          : StatusCodes.Status500InternalServerError;

        return result;
      }
      catch (Exception ex)
      {
        //TODO LS log
        HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        return false;
      }
    }

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<bool> Delete([FromQuery] Guid id)
    {
      try
      {
        bool result = await _service.DeleteAsync(id);

        HttpContext.Response.StatusCode = result
          ? StatusCodes.Status200OK
          : StatusCodes.Status500InternalServerError;

        return result;
      }
      catch (Exception ex) 
      {
        //TODO LS log
        HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        return false;
      }
    }
  }
}
