using System.Collections.Generic;
using System.Linq;
using medDatabase.Domain.Models;
using WebGrease.Css.Extensions;

namespace medDatabase.Web.Contexts.AttributeResolution
{
    public static class DoctorAttributeResolver
    {
        public static void ResolveDoctorSpecialties(IEnumerable<Doctor> doctors, IEnumerable<DoctorSpecialty> specialties)
        {
            doctors.ForEach(d => d.DoctorSpecialty = specialties.Single(ds => ds.Id == d.DoctorSpecialtyId));
        }

        public static void ResolveDoctorEmployees(IEnumerable<Doctor> doctors, IEnumerable<Employee> employees)
        {
            doctors.ForEach(d => d.Employee = employees.Single(e => e.Id == d.EmployeeId));
        }
    }
}