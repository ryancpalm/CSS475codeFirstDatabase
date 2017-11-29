using System.Collections.Generic;
using System.IO;
using medDatabase.Domain.Interfaces;
using Newtonsoft.Json;

namespace medDatabase.Domain.Mockaroo
{
    public class MockarooLoader : ILoader
    {
        public IEnumerable<T> LoadFromResource<T>(string resourceName)
        {
            var fileContents = ReadLinesFromResourceFile(resourceName);
            var objects = JsonConvert.DeserializeObject<IEnumerable<T>>(fileContents);
            return objects ?? new List<T>();
        }

        private static string ReadLinesFromResourceFile(string resourceName)
        {
            var employeesResource = medDatabase.Domain.Properties.Resources.ResourceManager.GetObject(resourceName);
            if (employeesResource == null)
            {
                return string.Empty;
            }
            var memoryStream = new MemoryStream((byte[]) employeesResource);
            var streamReader = new StreamReader(memoryStream);
            var fileContents = streamReader.ReadToEnd();
            return fileContents;
        }
    }
}
