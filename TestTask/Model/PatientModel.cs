using TestTask.Data.Enums;
using TestTask.Model.Interfaces;

namespace TestTask.Model
{
  public class PatientModel : IModel
  {
    public required NameModel Name { get; set; }
    public Gender? Gender { get; set; }
    public required DateTime BirthDate { get; set; }
    public Active? Active { get; set; }
  }
}
