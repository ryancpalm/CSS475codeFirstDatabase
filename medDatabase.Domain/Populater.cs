using System.Collections.Generic;
using System.Linq;
using medDatabase.Domain.Interfaces;
using medDatabase.Domain.Mockaroo;
using medDatabase.Domain.Mockaroo.Models;
using medDatabase.Domain.Models;

namespace medDatabase.Domain
{
    public class Populater : IPopulater
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            var mockarooEmployees = GetAllObjectsFromMockarooLoader<MockarooEmployee>("Employees");
            var employees = ConvertMockarooObjects(mockarooEmployees);
            return employees;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            var rooms = GetAllObjectsFromMockarooLoader<Room>("Rooms");
            return rooms;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            var mockarooPatients = GetAllObjectsFromMockarooLoader<MockarooPatient>("Patients");
            var patients = ConvertMockarooObjects(mockarooPatients);
            return patients;
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            var mockarooAddresses = GetAllObjectsFromMockarooLoader<MockarooAddress>("Addresses");
            var addresses = ConvertMockarooObjects(mockarooAddresses);
            return addresses;
        }

        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            var mockarooPrescriptions = GetAllObjectsFromMockarooLoader<MockarooPrescription>("Prescriptions");
            var prescriptions = ConvertMockarooObjects(mockarooPrescriptions);
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
            var mockarooAppointments = GetAllObjectsFromMockarooLoader<MockarooAppointment>("Appointments");
            var appointments = ConvertMockarooObjects(mockarooAppointments);
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
            var mockarooMedicalHistories = GetAllObjectsFromMockarooLoader<MockarooMedicalHistory>("Medical_Histories");
            var medicalHistories = ConvertMockarooObjects(mockarooMedicalHistories);
            return medicalHistories;
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            var mockarooDoctors = GetAllObjectsFromMockarooLoader<MockarooDoctor>("Doctors");
            var doctors = ConvertMockarooObjects(mockarooDoctors);
            return doctors;
        }

        public IEnumerable<Nurse> GetAllNurses()
        {
            var mockarooNurses = GetAllObjectsFromMockarooLoader<MockarooNurse>("Nurses");
            var nurses = ConvertMockarooObjects(mockarooNurses);
            return nurses;
        }

        private static IEnumerable<T> ConvertMockarooObjects<T>(IEnumerable<IMockarooConvertible<T>> mockarooObjects)
        {
            var convertedObjects = mockarooObjects.Select(mockarooObject => mockarooObject.Convert());
            return convertedObjects;
        }

        private static IEnumerable<T> GetAllObjectsFromMockarooLoader<T>(string resourceName)
        {
            var mockarooLoader = new MockarooLoader();
            var mockarooObjects = mockarooLoader.LoadFromResource<T>(resourceName);
            return mockarooObjects;
        }
    }
}
