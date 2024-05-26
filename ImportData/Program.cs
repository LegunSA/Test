using ImportData;
using ImportData.Model;
using ImportData.Model.Enums;
using System.Net.Http.Json;

Console.WriteLine("Press any key to start");
Console.ReadLine();

string[] _listOfMaleName = ["Ivan", "Petr", "Dmitriy", "Alexey", "Aleksandr", "Pavel", "Andrey", "Vitaliy", "Sergey", "Ruslan", "Vadim", "Danila", "Egor", "Denis"];
string[] _listOfMaleFamily = ["Ivanov", "Petrov", "Sidorov", "Pavlov", "Trofimoch", "Trofimov", "Aleksandrov", "Alekseev"];
string[] _listOfMaleSurname = ["Ivanovich", "Petrovich", "Dmitriyevich", "Alexeevich", "Aleksandrovich", "Pavelovich", "Andrevich", "Vitalievich", "Sergeevich", "Ruslanovich", "Vadimovich", "Danilovich", "Egorovich", "Denisovich"];

string[] _listOfFemaleName = ["Olga","Ekaterina","Larisa","Natalia","Ludmila","Natalia","Anna","Maria","Marina","Diana"];
string[] _listOfFemaleFamily = ["Ivanova", "Petrova", "Sidorova", "Pavlova", "Trofimoch", "Trofimova", "Aleksandrova", "Alekseeva"];
string[] _listOfFemaleSurame = ["Ivanovna", "Petrova", "Dmitrievna", "Alexeevna", "Aleksandrovna", "Pavelovna", "Andreevna", "Vitalievna", "Sergeevna", "Ruslanovna", "Vadimovna", "Danilovna", "Egorovna", "Denisovna"];

string[] _listOfUse = ["one", "two"];

int _countOfPatients = 100;
DateTime _startDateTime = new(2021, 1, 1, 0, 0, 0);
string url = "https://localhost:57239/api/Patient/create";

Random random = new Random();
List<Patient> patients = new List<Patient>();
HttpClient client = new HttpClient();

IPatientGenerator maleGenerator =
  new PatientGenerator(_listOfMaleName, _listOfMaleFamily, _listOfMaleSurname, _listOfUse, _startDateTime, Gender.male);

IPatientGenerator femaleGenerator =
  new PatientGenerator(_listOfFemaleName, _listOfFemaleFamily, _listOfFemaleSurame, _listOfUse, _startDateTime, Gender.female);

Dictionary<int,IPatientGenerator> patientGeneratorList = new Dictionary<int,IPatientGenerator>();
patientGeneratorList.Add(0, maleGenerator);
patientGeneratorList.Add(1, femaleGenerator);

for (int i = 0; i < _countOfPatients; i++) 
{
  var generator = patientGeneratorList[random.Next(0, patientGeneratorList.Count)];
  patients.Add(generator.GeneratePatient());
}
foreach (Patient patient in patients)
{
  await client.PostAsJsonAsync(url, patient);
}

Console.WriteLine("Compleate");

