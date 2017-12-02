using medDatabase.Domain.Models;

namespace medDatabase.Domain.Interfaces
{
    public interface IHasNurseSpecialty
    {
        int GetNurseSpecialtyId();
        void SetNurseSpecialty(NurseSpecialty specialty);
    }
}
