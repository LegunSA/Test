﻿using System.Text.Json.Serialization;

namespace TestTask.Data.Enums
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
