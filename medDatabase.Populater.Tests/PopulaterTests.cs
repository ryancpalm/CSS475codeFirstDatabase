using System.Linq;
using NUnit.Framework;

namespace medDatabase.Populater.Tests
{
    [TestFixture]
    public class PopulaterTests
    {
        [Test]
        public void PopulaterLoadsEmployees()
        {
            // Arrange
            var populater = new Populater();

            // Act
            var employees = populater.GetAllEmployees().ToList();

            // Assert
            Assert.That(employees, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsRooms()
        {
            // Arrange
            var populater = new Populater();
            
            // Act
            var rooms = populater.GetAllRooms().ToList();

            // Assert
            Assert.That(rooms, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsPatients()
        {
            // Arrange
            var populator = new Populater();

            // Act
            var patients = populator.GetAllPatients().ToList();

            // Assert
            Assert.That(patients, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsAddresses()
        {
            // Arrange
            var populater = new Populater();
            
            // Act
            var addresses = populater.GetAllAddresses().ToList();

            // Assert
            Assert.That(addresses, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsPrescriptions()
        {
            // Arrange
            var populator = new Populater();

            // Act
            var prescriptions = populator.GetAllPrescriptions();

            // Assert
            Assert.That(prescriptions, Is.Not.Empty);
        }
    }
}
