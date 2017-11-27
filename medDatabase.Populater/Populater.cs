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
            var mockarooEmployees = GetAllObjectsFromMockarooLoader<MockarooEmployee>(employeeResourceName);
            var employees = ConvertMockarooObjects(mockarooEmployees);
            return employees;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            const string roomResourceName = MockarooLoader.RoomResourceName;
            var rooms = GetAllObjectsFromMockarooLoader<Room>(roomResourceName);
            return rooms;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            const string patientResourceName = MockarooLoader.PatientResourceName;
            var mockarooPatients = GetAllObjectsFromMockarooLoader<MockarooPatient>(patientResourceName);
            var patients = ConvertMockarooObjects(mockarooPatients);
            return patients;
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            const string addressResourceName = MockarooLoader.AddressResourceName;
            var addresses = GetAllObjectsFromMockarooLoader<Address>(addressResourceName);
            return addresses;
        }

        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            const string prescriptionResourceName = MockarooLoader.PrescriptionResourceName;
            var mockarooPrescriptions = GetAllObjectsFromMockarooLoader<MockarooPrescription>(prescriptionResourceName);
            var prescriptions = ConvertMockarooObjects(mockarooPrescriptions);
            return prescriptions;
        }

        private static IEnumerable<T> ConvertMockarooObjects<T>(IEnumerable<IMockarooConvertible<T>> mockarooObjects)
        {
            var convertedObjects = mockarooObjects.Select(mockarooObject => mockarooObject.Convert());
            return convertedObjects;
        }

        private static IEnumerable<T> GetAllObjectsFromMockarooLoader<T>(string resourceName)
        {
            var mockarooLoader = new MockarooLoader();
            var mockarooObjects = mockarooLoader.LoadFromResource<T>(resourceName);
            return mockarooObjects;
        }
    }
}
