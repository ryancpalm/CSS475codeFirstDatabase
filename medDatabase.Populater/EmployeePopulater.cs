using System;
using System.Collections.Generic;
using medDatabase.Domain.Models;
using medDatabase.Populater.Interfaces;

namespace medDatabase.Populater
{
    public class EmployeePopulater : IPopulater<Employee>
    {
        private const string MockarooEmployeeDataPath = "Mockaroo/Employees.json";

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
