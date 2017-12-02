using medDatabase.Domain.Models;

namespace medDatabase.Domain.Interfaces
{
    public interface IHasDoctorSpecialty
    {
        int GetDoctorSpecialtyId();
        void SetDoctorSpecialty(DoctorSpecialty specialty);
    }
}
