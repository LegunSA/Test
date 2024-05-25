using System.Text.Json.Serialization;

namespace TestTask.Data.Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum SearchDatePrefix
  {
    eq, ne, lt, gt, ge, le, sa, eb, ap
  }
}
