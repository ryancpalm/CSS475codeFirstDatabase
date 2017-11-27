using System.Collections.Generic;
using System.Linq;
using medDatabase.Domain.Models;
using medDatabase.Populater.Interfaces;
using medDatabase.Populater.Mockaroo;
using medDatabase.Populater.Mockaroo.Models;

namespace medDatabase.Populater
{
    public class Populater : IPopulater
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            var mockarooLoader = new MockarooLoader();
            const string employeeResourceName = MockarooLoader.EmployeeResourceName;
            var mockarooEmployees = mockarooLoader.LoadFromResource<MockarooEmployee>(employeeResourceName);
            var employees = mockarooEmployees.Select(mockarooEmployee => mockarooEmployee.Convert());
            return employees;
        }
    }
}
