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
    public async Task<IEnumerable<PatientModel>?> GetFilteredByBirthDate([FromQuery] SearchDatePrefix prefix, DateTime date)
    {
      IEnumerable<PatientModel>? result = await GetPatientByDate(prefix, date);
      //TODO LS log
      return result;
    }

    [HttpGet("GetByBirthDate")]
    public async Task<IEnumerable<PatientModel>?> GetFiltered([FromQuery] string param)
    {
      DateTime date;
      SearchDatePrefix prefix;

      bool isDate = DateTime.TryParse(param.Substring(2), out date);
      bool isEnum = Enum.TryParse(param.Substring(0, 2), out prefix);

      IEnumerable<PatientModel>? result = (isEnum && isDate) ? await GetPatientByDate(prefix, date) : null;
      //TODO LS log
      return result;
    }

    private async Task<IEnumerable<PatientModel>?> GetPatientByDate(SearchDatePrefix prefix, DateTime date)
    {
      try
      {
        if (_service is IPatientService patientService)
        {
          Task<IEnumerable<Patient>?>? patients = patientService.GetPatientByDateAsync(prefix, date);

          return (patients != null) ? _mapper.Map<IEnumerable<PatientModel>?>(await patients) : null;
        }
        return null;
      }
      catch (Exception ex) { return null; }
    }
  }
}
