using System.Collections.Generic;
using System.Linq;
using medDatabase.Domain.Models;
using WebGrease.Css.Extensions;

namespace medDatabase.Web.Contexts.AttributeResolution
{
    public static class AddressAttributeResolver
    {
        public static void ResolvePatients(IEnumerable<Address> addresses, IEnumerable<Patient> patients)
        {
            addresses.ForEach(a => a.Patient = patients.Single(p => p.Id == a.PatientId));
        }
    }
}