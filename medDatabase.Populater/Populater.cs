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
            const string employeeResourceName = MockarooLoader.EmployeeResourceName;
            var mockarooEmployees = GetAllMockarooObjects<MockarooEmployee>(employeeResourceName);
            var employees = ConvertAllMockarooObjects(mockarooEmployees);
            return employees;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            const string roomResourceName = MockarooLoader.RoomResourceName;
            var mockarooRooms = GetAllMockarooObjects<MockarooRoom>(roomResourceName);
            var rooms = ConvertAllMockarooObjects(mockarooRooms);
            return rooms;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            const string patientResourceName = MockarooLoader.PatientResourceName;
            var mockarooPatients = GetAllMockarooObjects<MockarooPatient>(patientResourceName);
            var patients = ConvertAllMockarooObjects(mockarooPatients);
            return patients;
        }

        private static IEnumerable<T> ConvertAllMockarooObjects<T>(IEnumerable<IMockarooConvertible<T>> mockarooObjects)
        {
            var convertedObjects = mockarooObjects.Select(mockarooObject => mockarooObject.Convert());
            return convertedObjects;
        }

        private static IEnumerable<T> GetAllMockarooObjects<T>(string resourceName)
        {
            var mockarooLoader = new MockarooLoader();
            var mockarooObjects = mockarooLoader.LoadFromResource<T>(resourceName);
            return mockarooObjects;
        }
    }
}
