﻿using medDatabase.Web.Contexts;
using NUnit.Framework;

namespace medDatabase.Web.Integration.Tests
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
        public void MedicalDatabaseContextDatabaseExists()
        {
            // Act
            var dbExists = _medDbContext.Database.Exists();

            // Assert
            Assert.That(dbExists, Is.True);
        }
    }
}
