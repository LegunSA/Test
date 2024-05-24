using System.ComponentModel.DataAnnotations;
using TestTask.Data.Entityes.Interfaces;

namespace TestTask.Data.Entityes
{
  public class Entity : IEntity
  {
    [Key]
    public Guid Id { get; set; }
  }
}
