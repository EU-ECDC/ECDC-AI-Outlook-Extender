using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ECDC.Service.Files
{
    public class MetaDataManager : DataManagerBase<Dictionary<string, string>>
    {

        public MetaDataManager() : base(
            "metadata.json",
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ECDC-AIOX"))
        {
        }

        // Saves or updates a single metadata entry by key and value
        public void Save(string key, string value)
        {
            // Load existing metadata
            var data = Load();

            // Update or add the specified key-value pair
            data[key] = value;

            // Save the updated metadata back to the JSON file
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        // Gets a single metadata entry by key and value
        public string Load(string key)
        {
            // Load all metadata entries
            var data = Load();

            // Check if the specified key exists and return the value if found
            return data.ContainsKey(key) ? data[key] : string.Empty;

        }

        public override string ToString()
        {
            var data = Load();
            var ret = string.Empty;
            foreach (var item in data)
            {
                ret = ret + $"Category: «{item.Key}» \n Definition: «{item.Value}»\n";
            }
            return ret;
        }
    }
}
