using System.Text.Json.Serialization;

namespace ImportData.Model.Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum Gender
  {
    male,
    female,
    other,
    unknown
  }
}
