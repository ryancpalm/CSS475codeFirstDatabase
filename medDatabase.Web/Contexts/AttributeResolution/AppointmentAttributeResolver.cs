using System.Collections.Generic;
using System.Linq;
using medDatabase.Domain.Models;
using WebGrease.Css.Extensions;

namespace medDatabase.Web.Contexts.AttributeResolution
{
    public static class AppointmentAttributeResolver
    {
        public static void ResolvePatients(IEnumerable<Appointment> appointments, IEnumerable<Patient> patients)
        {
            appointments.ForEach(a => a.Patient = patients.Single(p => p.Id == a.PatientId));
        }

        public static void ResolveDoctors(IEnumerable<Appointment> appointments, IEnumerable<Doctor> docotrs)
        {
            appointments.ForEach(a => a.Doctor = docotrs.Single(d => d.EmployeeId == a.DoctorId).Employee);
        }
    }
}