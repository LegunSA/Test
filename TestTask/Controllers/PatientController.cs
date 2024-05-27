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

    [HttpGet("GetFilteredByBirthDate")]
    public IEnumerable<PatientModel>? GetFilteredByBirthDate([FromQuery] SearchDatePrefix prefix, DateTime date)
    {
      return GetPatientByDate(prefix, date);
    }

    [HttpGet("GetByBirthDate")]
    public IEnumerable<PatientModel>? GetFiltered([FromQuery] string param)
    {
      DateTime date;
      SearchDatePrefix prefix;

      bool isDate = DateTime.TryParse(param.Substring(2), out date);
      bool isEnum = Enum.TryParse(param.Substring(0, 2), out prefix);
      return (isEnum && isDate) ? GetPatientByDate(prefix, date) : null;
    }

    private IEnumerable<PatientModel>? GetPatientByDate(SearchDatePrefix prefix, DateTime date)
    {
      if (_service is IPatientService patientService)
      {
        return _mapper.Map<IEnumerable<PatientModel>?>(patientService.GetPatientByDate(prefix, date));
      }
      return null;
    }
  }
}
