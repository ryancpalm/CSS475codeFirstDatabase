using System.Linq;
using medDatabase.Domain.Mockaroo;
using medDatabase.Domain.Models;
using NUnit.Framework;

namespace medDatabase.Domain.Tests
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
            var mockarooEmployees = mockarooLoader.LoadFromResource<Employee>(invalidResourceName).ToList();

            // Assert
            Assert.That(mockarooEmployees, Is.Empty);
        }

        [Test]
        public void MockarooLoaderLoadsObjects()
        {
            // Arrange
            var mockarooLoader = new MockarooLoader();

            // Act
            var mockarooEmployees = mockarooLoader.LoadFromResource<Employee>("Employees").ToList();

            // Assert
            Assert.That(mockarooEmployees, Is.Not.Empty);
        }
    }
}
