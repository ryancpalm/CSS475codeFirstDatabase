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
            Assert.That(mockarooEmployees, Is.Not.Null);
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
            Assert.That(mockarooEmployees, Is.Not.Null);
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
    }
}
