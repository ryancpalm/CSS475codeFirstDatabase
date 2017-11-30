using System.Collections.Generic;
using System.Linq;
using medDatabase.Domain.Models;
using WebGrease.Css.Extensions;

namespace medDatabase.Web.Contexts.AttributeResolution
{
    public static class NurseAttributeResolver
    {
        public static void ResolveNurseSpecialties(IEnumerable<Nurse> nurses, IEnumerable<NurseSpecialty> specialties)
        {
            nurses.ForEach(n => n.NurseSpecialty = specialties.Single(ns => ns.Id == n.NurseSpecialtyId));
        }

        public static void ResolveEmployees(IEnumerable<Nurse> nurses, IEnumerable<Employee> employees)
        {
            nurses.ForEach(d => d.Employee = employees.Single(e => e.Id == d.EmployeeId));
        }
    }
}