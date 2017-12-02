using medDatabase.Domain.Models;

namespace medDatabase.Domain.Interfaces
{
    public interface IHasMedication
    {
        int GetMedicationId();
        void SetMedication(Medication medication);
    }
}
