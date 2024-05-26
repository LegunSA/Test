using ImportData.Model;

namespace ImportData.Interfaces
{
  internal interface ISender
  {
    Task SendAsync(IEnumerable<Patient> patients, string url);
  }
}
