using System.Collections.Generic;
using medDatabase.Domain.Models;

namespace medDatabase.Domain.Interfaces
{
    public interface IPopulater
    {
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Room> GetAllRooms();
        IEnumerable<Patient> GetAllPatients();
        IEnumerable<Prescription> GetAllPrescriptions();
        IEnumerable<DoctorSpecialty> GetAllDoctorSpecialties();
        IEnumerable<NurseSpecialty> GetAllNurseSpecialties();
        IEnumerable<Appointment> GetAllAppointments();
        IEnumerable<Illness> GetAllIllnesses();
        IEnumerable<Medication> GetAllMedications();
        IEnumerable<MedicalHistory> GetAllMedicalHistories();
    }
}
