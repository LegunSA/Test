using ImportData.Interfaces;
using ImportData.Model;
using ImportData.Model.Enums;

namespace ImportData
{
    internal class PatientGenerator : IPatientGenerator
  {
    private string[] _listOfName;
    private string[] _listOfFamily;
    private string[] _listOfSurname;
    private string[] _listOfUse;
    private DateTime _startDateTime;
    private Gender _gender;
    private static Array values = Enum.GetValues(typeof(Active));
    private static Random _random = new();

    internal PatientGenerator(
      string[] listOfName,
      string[] listOfFamily,
      string[] listOfSurname,
      string[] listOfUse,
      DateTime startDateTime,
      Gender gender)
    {
      _listOfName = listOfName;
      _listOfFamily = listOfFamily;
      _listOfSurname = listOfSurname;
      _listOfUse = listOfUse;
      _startDateTime = startDateTime;
      _gender = gender;
    }

    Patient IPatientGenerator.GeneratePatient()
    {
      Name name = new Name()
      {
        Family = Random(_listOfFamily),
        Given = [Random(_listOfName), Random(_listOfSurname)],
        Use = Random(_listOfUse)
      };

      Patient patient = new Patient()
      {
        BirthDate = RandomDateTime(_startDateTime),
        Name = name,
        Gender = _gender,
        Active = (Active)values.GetValue(_random.Next(values.Length))!
      };

      return patient;
    }

    private static string Random(string[] dictionary)
    {
      return dictionary[_random.Next(dictionary.Length)];
    }

    private static DateTime RandomDateTime(DateTime startDateTime)
    {
      int range = (DateTime.Today - startDateTime).Days;
      return startDateTime.AddDays(_random.Next(range)).AddHours(_random.Next(0, 24));
    }
  }
}
