using System;
using System.Linq;
using medDatabase.Domain.Models;
using medDatabase.Web.Contexts;
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
            //_medDbContext.Database.CreateIfNotExists();
        }

        [Test]
        public void MedicalDatabaseContextDatabaseExists()
        {
            var dbExists = _medDbContext.Database.Exists();
            Assert.That(dbExists, Is.True);
        }

        [Test]
        public void MedicalDatabaseEmployeesTableIsPopulated()
        {
            var employees = _medDbContext.Employees.ToList();
            Assert.That(employees, Is.Not.Empty);
        }
    }
}
