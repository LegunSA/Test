using ImportData.Model.Enums;

namespace ImportData.Model
{
  public class Patient
  {
    public required Name Name { get; set; }
    public Gender? Gender { get; set; }
    public required DateTime BirthDate { get; set; }
    public Active? Active { get; set; }
  }
}
