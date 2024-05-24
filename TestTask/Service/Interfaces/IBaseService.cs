using TestTask.Model.Interfaces;

namespace TestTask.Service.Interfaces
{
  public interface IBaseSrvice<Model> where Model : class, IModel
  {
    public Task<Model> GetAsync(Guid id);
    public Task<bool> AddAsync(Model model);
    public Task<bool> UpdateAsync(Model model);
    public Task<bool> DeleteAsync(Guid id);
    public Task<IEnumerable<Model>> GetAllAsync();
  }
}
