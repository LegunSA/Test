namespace ImportData.Model
{
  public class Name
  {
    public Guid? Id { get; set; }
    public string? Use { get; set; }
    public required string Family { get; set; }
    public string[]? Given { get; set; }
  }
}
