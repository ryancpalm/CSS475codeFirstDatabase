﻿using System.Linq;
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
    }
}