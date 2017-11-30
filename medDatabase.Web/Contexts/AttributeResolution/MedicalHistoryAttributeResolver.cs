using System.Collections.Generic;
using System.Linq;
using medDatabase.Domain.Models;
using WebGrease.Css.Extensions;

namespace medDatabase.Web.Contexts.AttributeResolution
{
    public static class MedicalHistoryAttributeResolver
    {
        public static void ResolvePatients(IEnumerable<MedicalHistory> medicalHistories, IEnumerable<Patient> patients)
        {
            medicalHistories.ForEach(mh => mh.Patient = patients.Single(p => p.Id == mh.PatientId));
        }

        public static void ResolveIllnesses(IEnumerable<MedicalHistory> medicalHistories, IEnumerable<Illness> illnesses)
        {
            medicalHistories.ForEach(mh => mh.Illness = illnesses.Single(i => i.Id == mh.IllnessId));
        }
    }
}