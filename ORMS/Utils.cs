﻿using System.Text.Json;

namespace ORMS;

internal class Utils
{
    public const string CONNECTION_STRING = "Server=PRECIOUS\\SQLEXPRESS;Database=DoggyDayCare;User Id=sa;Password=password;Trust Server Certificate=True";
    public static T DeserializeFromFile<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }
}
