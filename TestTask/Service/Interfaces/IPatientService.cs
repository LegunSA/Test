using TestTask.Data.Entityes;
using TestTask.Data.Enums;

namespace TestTask.Service.Interfaces
{
  public interface IPatientService : IBaseSrvice<Patient>
  {
    public Task<IEnumerable<Patient>?>? GetPatientByDateAsync(SearchDatePrefix prefix, DateTime date);
  }
}
