using System;
using medDatabase.Domain.Models;
using medDatabase.Populater.Interfaces;

namespace medDatabase.Populater.Mockaroo.Models
{
    public class MockarooEmployee : IMockarooConvertible<Employee>
    {
        public int Id { get; set; }
        public string Ssn { get; set; }
        public DateTime HireDate { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public bool OnSite { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee Convert()
        {
            var employee = new Employee
            {
                Id = Id,
                Ssn = RemoveHyphensFromSsn(Ssn),
                HireDate = HireDate,
                Age = Age,
                Gender = ConvertGender(Gender),
                FirstName = FirstName,
                LastName = LastName,
                OnSite = OnSite
            };
            return employee;
        }

        private static string RemoveHyphensFromSsn(string ssn)
        {
            var ssnWithoutHyphens = ssn.Replace("-", string.Empty);
            return ssnWithoutHyphens;
        }

        private static Gender ConvertGender(string gender)
        {
            var convertedGender = gender == "Male" ? Domain.Models.Gender.Male : Domain.Models.Gender.Female;
            return convertedGender;
        }
    }
}
