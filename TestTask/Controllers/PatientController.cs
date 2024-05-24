using Microsoft.AspNetCore.Mvc;
using TestTask.Model;
using TestTask.Service.Interfaces;

namespace TestTask.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PatientController : CRUDController<PatientModel>
  {
    public PatientController(IPatientService service) : base(service) { }
  }
}
