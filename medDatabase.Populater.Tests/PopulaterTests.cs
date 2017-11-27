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
    }
}
