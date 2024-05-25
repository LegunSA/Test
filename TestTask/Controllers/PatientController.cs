using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestTask.Data.Entityes;
using TestTask.Data.Enums;
using TestTask.Model;
using TestTask.Service.Interfaces;

namespace TestTask.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PatientController : CRUDController<PatientModel, Patient>
  {
    public PatientController(IPatientService service, IMapper mapper) : base(service, mapper) { }

    [HttpGet("list/{prefix}${date:datetime}")]
    public IEnumerable<Patient>? GetFilteredByDate(SearchDatePrefix prefix, DateTime date)
    {
      if (_service is IPatientService patientService)
      {
        IEnumerable<Entity>? items = patientService.GetPatientByDate(prefix, date);

        return _mapper.Map<IEnumerable<Patient>?>(items);
      }
      return null;
    }

    [HttpGet("list/param=")]
    public IEnumerable<Patient>? GetFiltered(string param)
    {
      DateTime date;
      SearchDatePrefix prefix;

      bool isDate = DateTime.TryParse(param.Substring(2), out date);
      bool isEnum = Enum.TryParse(param.Substring(0, 2), out prefix);

      if (isEnum && isDate && _service is IPatientService patientService)
      {
        IEnumerable<Entity>? items = patientService.GetPatientByDate(prefix, date);

        return _mapper.Map<IEnumerable<Patient>?>(items);
      }
      return null;
    }
  }
}
