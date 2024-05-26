using ImportData.Model;

namespace ImportData.Interfaces
{
  internal interface IPatientsBuilder
  {
    internal IEnumerable<Patient> BuildPatientList(int countOfPatients);
  }
}
