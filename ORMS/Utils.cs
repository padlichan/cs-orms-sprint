﻿using System.Text.Json;

namespace ORMS
{
    internal class Utils
    {
        public const string CONNECTION_STRING = "Server=<server_name>;Database=DoggyDayCare;User Id=<user_id>;Password=<password>;Trust Server Certificate=True";
        public static T DeserializeFromFile<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
