using System.Linq;
using medDatabase.Domain;
using medDatabase.Domain.Interfaces;
using medDatabase.Domain.Validation;
using medDatabase.Web.Contexts;
using NUnit.Framework;

namespace medDatabase.Web.Integration.Tests
{
    [TestFixture]
    public class AttributeResolverTests
    {
        private IPopulater _populater;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            _populater = new Populater();
        }

        [Test]
        public void AttributeResolverResolvesSSNs()
        {
            // Arrange
            var employees = _populater.GetAllEmployees().ToList();
            var patients = _populater.GetAllPatients().ToList();

            // Act
            AttributeResolver.ResolveSSNs(employees);
            AttributeResolver.ResolveSSNs(patients);

            // Assert
            var ssnValidator = new SsnValidationAttribute();
            bool ssnIsValid;
            foreach (var employee in employees)
            {
                ssnIsValid = ssnValidator.IsValid(employee.Ssn);
                Assert.True(ssnIsValid);
            }
            foreach (var patient in patients)
            {
                ssnIsValid = ssnValidator.IsValid(patient.Ssn);
                Assert.True(ssnIsValid);
            }
        }

        [Test]
        public void AttributeResolverResolvesEmployees()
        {
            // Arrange
            var doctors = _populater.GetAllDoctors().ToList();
            var employees = _populater.GetAllEmployees().ToList();

            // Act
            foreach (var doctor in doctors)
            {
                AttributeResolver.ResolveEmployee(doctor, employees);

                //Assert
                Assert.That(doctor.Employee, Is.Not.Null);
                Assert.That(doctor.Employee.Id, Is.EqualTo(doctor.EmployeeId));
            }
        }

        [Test]
        public void AttributeResolverResolvesDoctorSpecialties()
        {
            // Arrange
            var doctors = _populater.GetAllDoctors().ToList();
            var specialties = _populater.GetAllDoctorSpecialties().ToList();

            // Act
            foreach (var doctor in doctors)
            {
                AttributeResolver.ResolveDoctorSpecialty(doctor, specialties);

                // Assert
                Assert.That(doctor.DoctorSpecialty, Is.Not.Null);
                Assert.That(doctor.DoctorSpecialty.Id, Is.EqualTo(doctor.DoctorSpecialtyId));
            }
        }

        [Test]
        public void AttributeResolverResolvesRooms()
        {
            // Arrange
            var rooms = _populater.GetAllRooms().ToList();
            var patients = _populater.GetAllPatients().ToList();

            // Act
            foreach (var patient in patients)
            {
                AttributeResolver.ResolveRoom(patient, rooms);

                // Assert
                Assert.That(patient.Room, Is.Not.Null);
                Assert.That(patient.Room.Id, Is.EqualTo(patient.RoomId));
            }
        }
    }
}
