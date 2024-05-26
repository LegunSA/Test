using ImportData.Interfaces;
using ImportData.Model;


namespace ImportData
{
  internal class PatientsBuilder : IPatientsBuilder
  {
    private Dictionary<int, IPatientGenerator> _patientGenerators;
    private static Random random = new Random();
    public PatientsBuilder(Dictionary<int, IPatientGenerator> patientGenerators)
    {
      _patientGenerators = patientGenerators;
    }
    IEnumerable<Patient> IPatientsBuilder.BuildPatientList(int countOfPatients)
    {
      List<Patient> patients = new List<Patient>();
      for (int i = 0; i < countOfPatients; i++)
      {
        var generator = _patientGenerators[random.Next(0, _patientGenerators.Count)];
        patients.Add(generator.GeneratePatient());
      }
      return patients;
    }
  }
}
