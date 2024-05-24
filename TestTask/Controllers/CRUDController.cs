using Microsoft.AspNetCore.Mvc;
using TestTask.Model.Interfaces;
using TestTask.Service.Interfaces;

namespace TestTask.Controllers
{
  public class CRUDController<Model> : ControllerBase where Model : class, IModel
  {
    protected IBaseSrvice<Model> _service;

    public CRUDController(IBaseSrvice<Model> service)
    {
      _service = service;
    }

    [HttpGet("list")]
    public async Task<IEnumerable<Model>> GetAll()
    {
      return await _service.GetAllAsync();
    }

    [HttpGet("get/{id:Guid}")]
    public async Task<Model> Get(Guid id)
    {
      return await _service.GetAsync(id);
    }

    [HttpPost("create")]
    public async Task<bool> Create(Model item)
    {
      return await _service.AddAsync(item);
    }

    [HttpPut("edit")]
    public async Task<bool> Update(Model item)
    {
      return await _service.UpdateAsync(item);
    }

    [HttpDelete("delete/{id:Guid}")]
    public async Task<bool> Delete(Guid id)
    {
      return await _service.DeleteAsync(id);
    }
  }
}
