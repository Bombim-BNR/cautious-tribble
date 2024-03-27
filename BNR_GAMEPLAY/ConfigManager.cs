using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BNR_GAMEPLAY
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;

    public class ConfigManager
    {
        private Dictionary<string, string> stringDictionary;
        private string filePath;

        public string this[string name]
        {
            get { return Get(name); }
            set { Update(name, value); }
        }

        public bool ContainsName(string name) => stringDictionary.ContainsKey(name);

        public ConfigManager(string filePath)
        {
            if (File.Exists(filePath))
            {
                this.filePath = filePath;
            }
            else
            {
                throw new FileNotFoundException("File does not exist");
            }
            stringDictionary = new Dictionary<string, string>();
        }

        public void Save()
        {
            string jsonString = JsonSerializer.Serialize(stringDictionary);
            File.WriteAllText(filePath, jsonString);
        }

        public void Add(string name, string value)
        {
            if (stringDictionary.ContainsKey(name))
            {
                throw new ArgumentException($"JSON already contains {name}");
            }
            else
            {
                stringDictionary.Add(name, value);
            }
        }

        public void Update(string name, string value)
        {
            if (stringDictionary.ContainsKey(name))
            {
                stringDictionary[name] = value;
            }
            else
            {
                throw new KeyNotFoundException($"Data with name '{name}' does not exist");
            }
        }

        public void UpdateOrAdd(string name, string value)
        {
            if (stringDictionary.ContainsKey(name))
            {
                stringDictionary[name] = value;
            }
            else
            {
                stringDictionary.Add(name, value);
            }
        }

        public string Get(string name)
        {
            if (stringDictionary.ContainsKey(name))
            {
                return stringDictionary[name];
            }
            else
            {
                throw new KeyNotFoundException($"Data with name '{name}' does not exist");
            }
        }

        public void Remove(string name)
        {
            if (stringDictionary.ContainsKey(name))
            {
                stringDictionary.Remove(name);
            }
            else
            {
                throw new KeyNotFoundException($"Data with name '{name}' does not exist");
            }
        }

        public void Load()
        {

            string jsonString = File.ReadAllText(filePath);
            if(jsonString == "")
            {
                throw new IOException("File is empty");
            }
            stringDictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString) ?? new Dictionary<string, string>();
        }
    }

}
