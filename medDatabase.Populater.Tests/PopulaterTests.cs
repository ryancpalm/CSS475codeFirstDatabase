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
            Assert.That(employees, Is.Not.Null);
            Assert.That(employees, Is.Not.Empty);
        }
    }
}
