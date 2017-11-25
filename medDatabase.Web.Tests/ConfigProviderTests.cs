using NUnit.Framework;

namespace medDatabase.Web.Tests
{
    [TestFixture]
    public class ConfigProviderTests
    {
        private ConfigProvider _configProvider;

        [SetUp]
        public void BeforeEach()
        {
            _configProvider = new ConfigProvider();
        }

        [Test]
        public void ConfigProviderLoadsMedicalDatabaseConnectionString()
        {
            var medicalDatabaseConnectionStringKey = _configProvider.GetMedicalDatabaseConnectionStringSettings();
            Assert.That(medicalDatabaseConnectionStringKey, Is.Not.Null);
        }
    }
}
