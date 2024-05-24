using TestTask.Model.Interfaces;

namespace TestTask.Model
{
  public class NameModel : IModel
  {
    public required Guid Id { get; set; }
    public string? Use { get; set; }
    public required string Family { get; set; }
    public string[]? Given { get; set; }
  }
}
