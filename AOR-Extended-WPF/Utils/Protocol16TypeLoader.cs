using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using AOR_Extended_WPF.Enumerations;

namespace AOR_Extended_WPF.Utils
{
    public static class Protocol16TypeLoader
    {
        public static Dictionary<string, Protocol16Type> LoadProtocol16Types(string jsonFilePath)
        {
            if (!File.Exists(jsonFilePath))
            {
                throw new FileNotFoundException($"The file {jsonFilePath} does not exist.");
            }

            var jsonString = File.ReadAllText(jsonFilePath);
            var protocol16Types = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonString);

            return protocol16Types.ToDictionary(
                kvp => kvp.Key,
                kvp => (Protocol16Type)kvp.Value
            );
        }
    }
}
