using System.Collections.Generic;
using System.Linq;
using medDatabase.Domain.Interfaces;
using medDatabase.Domain.Models;

namespace medDatabase.Web.Contexts.AttributeResolution
{
    public static class AttributeResolver
    {
        public static void ResolveEmployee(IHasEmployee model, IEnumerable<Employee> employees)
        {
            var employee = employees.Single(e => e.Id == model.GetEmployeeId());
            model.SetEmployee(employee);
        }

        public static void ResolvePatient(IHasPatient model, IEnumerable<Patient> patients)
        {
            var patient = patients.Single(p => p.Id == model.GetPatientId());
            model.SetPatient(patient);
        }

        public static void ResolveMedication(IHasMedication model, IEnumerable<Medication> medications)
        {
            var medication = medications.Single(m => m.Id == model.GetMedicationId());
            model.SetMedication(medication);
        }

        public static void ResolveIllness(IHasIllness model, IEnumerable<Illness> illnesses)
        {
            var illness = illnesses.Single(i => i.Id == model.GetIllnessId());
            model.SetIllness(illness);
        }

        public static void ResolveRoom(IHasRoom model, IEnumerable<Room> rooms)
        {
            var room = rooms.Single(r => r.Id == model.GetRoomId());
            model.SetRoom(room);
        }

        public static void ResolveDoctorSpecialty(IHasDoctorSpecialty model, IEnumerable<DoctorSpecialty> specialties)
        {
            var specialty = specialties.Single(s => s.Id == model.GetDoctorSpecialtyId());
            model.SetDoctorSpecialty(specialty);
        }

        public static void ResolveNurseSpecialty(IHasNurseSpecialty model, IEnumerable<NurseSpecialty> specialties)
        {
            var specialty = specialties.Single(s => s.Id == model.GetNurseSpecialtyId());
            model.SetNurseSpecialty(specialty);
        }
    }
}