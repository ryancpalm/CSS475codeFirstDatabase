using System.Collections.Generic;
using System.IO;
using medDatabase.Populater.Interfaces;
using Newtonsoft.Json;

namespace medDatabase.Populater.Mockaroo
{
    public class MockarooLoader : ILoader
    {
        public const string EmployeeResourceName = "Employees";
        public const string RoomResourceName = "Rooms";
        public const string PatientResourceName = "Patients";
        public const string AddressResourceName = "Addresses";
        public const string PrescriptionResourceName = "Prescriptions";

        public IEnumerable<T> LoadFromResource<T>(string resourceName)
        {
            var fileContents = ReadLinesFromResourceFile(resourceName);
            var objects = JsonConvert.DeserializeObject<IEnumerable<T>>(fileContents);
            return objects ?? new List<T>();
        }

        private static string ReadLinesFromResourceFile(string resourceName)
        {
            var employeesResource = medDatabase.Populater.Properties.Resources.ResourceManager.GetObject(resourceName);
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
