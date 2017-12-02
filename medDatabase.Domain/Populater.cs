using System.Collections.Generic;
using medDatabase.Domain.Interfaces;
using medDatabase.Domain.Mockaroo;
using medDatabase.Domain.Models;

namespace medDatabase.Domain
{
    public class Populater : IPopulater
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = GetAllObjectsFromMockarooLoader<Employee>("Employees");
            return employees;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            var rooms = GetAllObjectsFromMockarooLoader<Room>("Rooms");
            return rooms;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            var patients = GetAllObjectsFromMockarooLoader<Patient>("Patients");
            return patients;
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            var addresses = GetAllObjectsFromMockarooLoader<Address>("Addresses");
            return addresses;
        }

        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            var prescriptions = GetAllObjectsFromMockarooLoader<Prescription>("Prescriptions");
            return prescriptions;
        }

        public IEnumerable<DoctorSpecialty> GetAllDoctorSpecialties()
        {
            var doctorSpecialties = GetAllObjectsFromMockarooLoader<DoctorSpecialty>("Doctor_Specialties");
            return doctorSpecialties;
        }

        public IEnumerable<NurseSpecialty> GetAllNurseSpecialties()
        {
            var nurseSpecialties = GetAllObjectsFromMockarooLoader<NurseSpecialty>("Nurse_Specialties");
            return nurseSpecialties;
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            var appointments = GetAllObjectsFromMockarooLoader<Appointment>("Appointments");
            return appointments;
        }

        public IEnumerable<Illness> GetAllIllnesses()
        {
            var illnesses = GetAllObjectsFromMockarooLoader<Illness>("Illnesses");
            return illnesses;
        }

        public IEnumerable<Medication> GetAllMedications()
        {
            var medications = GetAllObjectsFromMockarooLoader<Medication>("Medications");
            return medications;
        }

        public IEnumerable<MedicalHistory> GetAllMedicalHistories()
        {
            var medicalHistories = GetAllObjectsFromMockarooLoader<MedicalHistory>("Medical_Histories");
            return medicalHistories;
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            var doctors = GetAllObjectsFromMockarooLoader<Doctor>("Doctors");
            return doctors;
        }

        public IEnumerable<Nurse> GetAllNurses()
        {
            var nurses = GetAllObjectsFromMockarooLoader<Nurse>("Nurses");
            return nurses;
        }

        private static IEnumerable<T> GetAllObjectsFromMockarooLoader<T>(string resourceName)
        {
            var mockarooLoader = new MockarooLoader();
            var mockarooObjects = mockarooLoader.LoadFromResource<T>(resourceName);
            return mockarooObjects;
        }
    }
}
