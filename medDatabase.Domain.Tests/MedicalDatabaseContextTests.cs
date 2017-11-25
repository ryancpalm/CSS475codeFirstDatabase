using medDatabase.Domain.Contexts;
using NUnit.Framework;

namespace medDatabase.Domain.Tests
{
    [TestFixture]
    public class MedicalDatabaseContextTests
    {
        private MedicalDatabaseContext _medDbContext;

        [SetUp]
        public void BeforeEach()
        {
            _medDbContext = new MedicalDatabaseContext();
            _medDbContext.Database.CreateIfNotExists();
        }

        [Test]
        public void MedicalDatabaseContextCanConnectToServer()
        {
            // Act
            var databaseConnection = _medDbContext.Database.Connection;

            // Assert
            Assert.That(databaseConnection, Is.Not.Null);
        }

        [Test]
        public void MedicalDatabaseContextDatabaseExists()
        {
            // Act
            var dbExists = _medDbContext.Database.Exists();

            // Assert
            Assert.That(dbExists, Is.True);
        }
    }
}
