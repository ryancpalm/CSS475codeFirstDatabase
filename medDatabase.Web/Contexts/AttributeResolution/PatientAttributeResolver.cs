using System.Collections.Generic;
using System.Linq;
using medDatabase.Domain.Models;
using WebGrease.Css.Extensions;

namespace medDatabase.Web.Contexts.AttributeResolution
{
    public static class PatientAttributeResolver
    {
        public static void ResolveRooms(IEnumerable<Patient> patients, IEnumerable<Room> rooms)
        {
            patients.ForEach(p => p.Room = rooms.Single(r => r.Id == p.Id));
        }
    }
}