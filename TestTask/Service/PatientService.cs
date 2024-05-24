using AutoMapper;
using TestTask.Data.Entityes;
using TestTask.Data.Interfaces;
using TestTask.Model;
using TestTask.Service.Interfaces;

namespace TestTask.Service
{
  public class PatientService : BaseService<Patient, PatientModel>, IPatientService
  {
    public PatientService(IMapper mapper, IRepository repository) : base(mapper, repository) { }
  }
}
