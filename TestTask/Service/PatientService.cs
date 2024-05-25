using AutoMapper;
using TestTask.Data.Entityes;
using TestTask.Data.Enums;
using TestTask.Data.Interfaces;
using TestTask.Service.Interfaces;

namespace TestTask.Service
{
  public class PatientService : BaseService<Patient>, IPatientService
  {
    public PatientService(IMapper mapper, IRepository repository) : base(mapper, repository) { }

    public IEnumerable<Patient>? GetPatientByDate(SearchDatePrefix prefix, DateTime date)
    {
      Func<Patient, bool> condition;

      switch (prefix)
      {
        case SearchDatePrefix.eq:
          condition = x => x.BirthDate.Date == date.Date;
          break;
        case SearchDatePrefix.ne:
          condition = x => x.BirthDate.Date != date.Date;
          break;
        case SearchDatePrefix.lt:
          condition = x => x.BirthDate == date;
          break;
        case SearchDatePrefix.gt:
          condition = x => x.BirthDate == date;
          break;
        case SearchDatePrefix.ge:
          condition = x => x.BirthDate == date;
          break;
        case SearchDatePrefix.le:
          condition = x => x.BirthDate == date;
          break;
        case SearchDatePrefix.sa:
          condition = x => x.BirthDate == date;
          break;
        case SearchDatePrefix.eb:
          condition = x => x.BirthDate == date;
          break;
        case SearchDatePrefix.ap:
          condition = x => x.BirthDate == date;
          break;
        default:
          condition = x => x.BirthDate == date;
          break;
      }
      var res = _repository.GetByFilter<Patient>(x => x.BirthDate == date);
      return res;
    }
  }
}
