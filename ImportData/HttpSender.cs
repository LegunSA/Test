using ImportData.Interfaces;
using ImportData.Model;
using System.Net.Http.Json;

namespace ImportData
{
  internal class HttpSender : ISender
  {
    HttpClient client = new HttpClient();
    public async Task SendAsync(IEnumerable<Patient> patients, string url)
    {
      foreach (Patient patient in patients)
      {
        await client.PostAsJsonAsync(url, patient);
      }
    }
  }
}
