using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestTask.Data.Entityes;
using TestTask.Model;
using TestTask.Service.Interfaces;

namespace TestTask.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PatientController : CRUDController<PatientModel, Patient>
  {
    public PatientController(IPatientService service, IMapper mapper) : base(service, mapper) { }
  }
}
