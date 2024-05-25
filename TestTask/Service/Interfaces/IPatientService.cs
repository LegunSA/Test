using TestTask.Data.Entityes;
using TestTask.Data.Enums;

namespace TestTask.Service.Interfaces
{
  public interface IPatientService : IBaseSrvice<Patient>
  {
    public IEnumerable<Patient>? GetPatientByDate(SearchDatePrefix prefix, DateTime date);
  }
}
