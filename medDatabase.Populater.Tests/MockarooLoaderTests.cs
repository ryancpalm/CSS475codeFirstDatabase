using System.Collections.Generic;
using System.Linq;
using medDatabase.Domain.Models;
using medDatabase.Populater.Mockaroo;
using medDatabase.Populater.Mockaroo.Models;
using NUnit.Framework;

namespace medDatabase.Populater.Tests
{
    [TestFixture]
    public class MockarooLoaderTests
    {
        [Test]
        public void MockarooLoaderReturnsEmptyWithInvalidResourceName()
        {
            // Arrange
            var mockarooLoader = new MockarooLoader();
            const string invalidResourceName = "InvalidResourceName";

            // Act
            var mockarooEmployees = mockarooLoader.LoadFromResource<MockarooEmployee>(invalidResourceName).ToList();

            // Assert
            Assert.That(mockarooEmployees, Is.Empty);
        }

        [Test]
        public void MockarooLoaderLoadsMockarooEmployees()
        {
            // Arrange
            var mockarooLoader = new MockarooLoader();
            const string resourceName = MockarooLoader.EmployeeResourceName;

            // Act
            var mockarooEmployees = mockarooLoader.LoadFromResource<MockarooEmployee>(resourceName).ToList();

            // Assert
            Assert.That(mockarooEmployees, Is.Not.Empty);
        }

        [Test]
        public void MocarkooLoaderLoadedMockarooEmployeesConvert()
        {
            // Arrange
            var mockarooLoader = new MockarooLoader();
            const string resourceName = MockarooLoader.EmployeeResourceName;
            var mockarooEmployees = mockarooLoader.LoadFromResource<MockarooEmployee>(resourceName).ToList();

            // Act, Assert
            var employees = new List<Employee>();
            foreach (var mockarooEmployee in mockarooEmployees)
            {
                Assert.DoesNotThrow(() => mockarooEmployee.Convert());
                var employee = mockarooEmployee.Convert();
                employees.Add(employee);
            }
            Assert.That(employees.Count, Is.EqualTo(mockarooEmployees.Count));
        }

        [Test]
        public void MockarooLoaderLoadsRooms()
        {
            // Arrange
            var mockarooLoader = new MockarooLoader();
            const string resourceName = MockarooLoader.RoomResourceName;

            // Act
            var rooms = mockarooLoader.LoadFromResource<Room>(resourceName).ToList();

            // Assert
            Assert.That(rooms, Is.Not.Empty);
        }

        [Test]
        public void MockarooLoaderLoadsMockarooPatients()
        {
            // Arrange
            var mockarooLoader = new MockarooLoader();
            const string resourceName = MockarooLoader.PatientResourceName;

            // Act
            var mockarooPatients = mockarooLoader.LoadFromResource<MockarooPatient>(resourceName).ToList();

            // Assert
            Assert.That(mockarooPatients, Is.Not.Empty);
        }

        [Test]
        public void MockarooLoaderLoadsAddresses()
        {
            // Arrange
            var mockarooLoader = new MockarooLoader();
            const string resourceName = MockarooLoader.AddressResourceName;

            // Act
            var addresses = mockarooLoader.LoadFromResource<Address>(resourceName).ToList();

            // Assert
            Assert.That(addresses, Is.Not.Empty);
        }

        [Test]
        public void MockarooLoaderLoadsMockarooPrescriptions()
        {
            // Arrange
            var mockarooLoader = new MockarooLoader();
            const string resourceName = MockarooLoader.PrescriptionResourceName;

            // Act
            var mockarooPrescriptions = mockarooLoader.LoadFromResource<MockarooPatient>(resourceName).ToList();

            // Assert
            Assert.That(mockarooPrescriptions, Is.Not.Empty);
        }
    }
}
