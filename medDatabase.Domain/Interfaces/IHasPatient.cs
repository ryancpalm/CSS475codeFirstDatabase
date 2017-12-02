using medDatabase.Domain.Models;

namespace medDatabase.Domain.Interfaces
{
    public interface IHasPatient
    {
        int GetPatientId();
        void SetPatient(Patient patient);
    }
}
