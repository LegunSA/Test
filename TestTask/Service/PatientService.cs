using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;
using TestTask.Data.Entityes;
using TestTask.Data.Enums;
using TestTask.Data.Interfaces;
using TestTask.Service.Interfaces;

namespace TestTask.Service
{
  public class PatientService : BaseService<Patient>, IPatientService
  {
    public PatientService(IMapper mapper, IRepository repository) : base(mapper, repository) { }

    public async Task<IEnumerable<Patient>?>? GetPatientByDateAsync(SearchDatePrefix prefix, DateTime date)
    {
      try
      {
        Expression<Func<Patient, bool>> condition; ;

        switch (prefix)
        {
          case SearchDatePrefix.eq:
            condition = x => x.BirthDate.Date == date.Date;
            break;
          case SearchDatePrefix.ne:
            condition = x => x.BirthDate.Date != date.Date;
            break;
          case SearchDatePrefix.lt:
          case SearchDatePrefix.eb:
            condition = x => x.BirthDate.Date < date.Date;
            break;
          case SearchDatePrefix.gt:
          case SearchDatePrefix.sa:
            condition = x => x.BirthDate.Date > date.Date;
            break;
          case SearchDatePrefix.ge:
            condition = x => x.BirthDate >= date;
            break;
          case SearchDatePrefix.le:
            condition = x => x.BirthDate <= date;
            break;
          case SearchDatePrefix.ap:
            DateTime start = date.AddMinutes(-90);
            DateTime end = date.AddHours(24).AddMinutes(90);
            condition = x => start < x.BirthDate && x.BirthDate < end;
            break;
          default:
            condition = x => x.BirthDate == date;
            break;
        }

        IQueryable<Patient>? patients = _repository.GetByFilter(condition)?.OrderBy(x => x.BirthDate);

        return (patients != null) ? await patients.ToListAsync() : null;
      }
      catch (ArgumentNullException ex)
      {
        return null;
      }
      catch (ArgumentOutOfRangeException ex)
      {
        return null;
      }
    }
  }
}
