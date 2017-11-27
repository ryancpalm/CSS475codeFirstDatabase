using System;
using medDatabase.Domain.Validation;
using medDatabase.Populater.Mockaroo.Models;
using NUnit.Framework;

namespace medDatabase.Populater.Tests
{
    [TestFixture]
    public class MockarooEmployeeTests
    {
        [Test]
        public void MockarooEmployeeConvertsValidSsn()
        {
            // Arrange
            var mockarooEmployee = CreateValidMockarooEmployee();

            // Act
            var employee = mockarooEmployee.Convert();

            // Assert
            var ssnValidtor = new SsnValidationAttribute();
            var ssnIsValid = ssnValidtor.IsValid(employee.Ssn);
            Assert.That(ssnIsValid, Is.True);
        }

        private static MockarooEmployee CreateValidMockarooEmployee()
        {
            var mockarooEmployee = new MockarooEmployee
            {
                Id = 0,
                Age = 20,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Gender = "Female",
                HireDate = DateTime.Parse("01/01/2017"),
                OnSite = true,
                Ssn = "123-45-6789"
            };
            return mockarooEmployee;
        }
    }
}
