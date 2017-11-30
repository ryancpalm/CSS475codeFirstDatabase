using System.Collections.Generic;
using System.Linq;
using medDatabase.Domain.Models;
using WebGrease.Css.Extensions;

namespace medDatabase.Web.Contexts.AttributeResolution
{
    public static class PrescriptionAttributeResolver
    {
        public static void ResolvePatients(IEnumerable<Prescription> prescriptions, IEnumerable<Patient> patients)
        {
            prescriptions.ForEach(pr => pr.Patient = patients.Single(p => p.Id == pr.PatientId));
        }

        public static void ResolveDoctors(IEnumerable<Prescription> prescriptions, IEnumerable<Doctor> doctors)
        {
            prescriptions.ForEach(pr => pr.Doctor = doctors.Single(d => d.EmployeeId == pr.DoctorId).Employee);
        }

        public static void ResolveMedications(IEnumerable<Prescription> prescriptions,
            IEnumerable<Medication> medications)
        {
            prescriptions.ForEach(pr => pr.Medication = medications.Single(m => m.Id == pr.MedicationId));
        }
    }
}