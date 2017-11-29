using System.Linq;
using NUnit.Framework;

namespace medDatabase.Domain.Tests
{
    [TestFixture]
    public class PopulaterTests
    {
        [Test]
        public void PopulaterLoadsEmployees()
        {
            // Arrange
            var populater = new Domain.Populater();

            // Act
            var employees = populater.GetAllEmployees().ToList();

            // Assert
            Assert.That(employees, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsRooms()
        {
            // Arrange
            var populater = new Domain.Populater();
            
            // Act
            var rooms = populater.GetAllRooms().ToList();

            // Assert
            Assert.That(rooms, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsPatients()
        {
            // Arrange
            var populator = new Domain.Populater();

            // Act
            var patients = populator.GetAllPatients().ToList();

            // Assert
            Assert.That(patients, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsAddresses()
        {
            // Arrange
            var populater = new Domain.Populater();
            
            // Act
            var addresses = populater.GetAllAddresses().ToList();

            // Assert
            Assert.That(addresses, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsPrescriptions()
        {
            // Arrange
            var populator = new Domain.Populater();

            // Act
            var prescriptions = populator.GetAllPrescriptions().ToList();

            // Assert
            Assert.That(prescriptions, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsDoctorSpecialties()
        {
            // Arrange
            var populator = new Populater();

            // Act
            var doctorSpecialties = populator.GetAllDoctorSpecialties().ToList();

            // Assert
            Assert.That(doctorSpecialties, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsNurseSpecialties()
        {
            // Arrange
            var populator = new Populater();
            
            // Act
            var nurseSpecialties = populator.GetAllNurseSpecialties().ToList();

            // Assert
            Assert.That(nurseSpecialties, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsAppointments()
        {
            // Arrange
            var populator = new Populater();
            
            // Act
            var appointments = populator.GetAllAppointments();

            // Assert
            Assert.That(appointments, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsIllnesses()
        {
            // Arrange
            var populator = new Populater();
            
            // Act
            var illnesses = populator.GetAllIllnesses();

            // Assert
            Assert.That(illnesses, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsMedications()
        {
            // Arrange
            var populator = new Populater();

            // Act
            var medications = populator.GetAllMedications();

            // Assert
            Assert.That(medications, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsMedicalHistories()
        {
            // Arrange
            var populator = new Populater();

            // Act
            var medicalHistories = populator.GetAllMedicalHistories();

            // Assert
            Assert.That(medicalHistories, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsDoctors()
        {
            // Arrange
            var populator = new Populater();

            // Act
            var doctors = populator.GetAllDoctors();

            // Assert
            Assert.That(doctors, Is.Not.Empty);
        }

        [Test]
        public void PopulaterLoadsNurses()
        {
            // Arrange
            var populator = new Populater();

            // Act
            var nurses = populator.GetAllNurses();

            // Assert
            Assert.That(nurses, Is.Not.Empty);
        }
    }
}
