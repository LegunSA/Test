using TestTask.Model.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Model
{
  public class NameModel : IModel
  {
    public Guid? Id { get; set; }
    public string? Use { get; set; }
    [Required]
    public required string Family { get; set; }
    public string[]? Given { get; set; }
  }
}
