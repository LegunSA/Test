using TestTask.Data.Enums;

namespace TestTask.Data.Entityes
{
  public class Patient : Entity
  {
    public string? Use { get; set; }
    public required string Family { get; set; }
    public string[]? Given { get; set; }
    public Gender? Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public bool? Active { get; set; }
  }
}
