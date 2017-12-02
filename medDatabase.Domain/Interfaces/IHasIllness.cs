using medDatabase.Domain.Models;

namespace medDatabase.Domain.Interfaces
{
    public interface IHasIllness
    {
        int GetIllnessId();
        void SetIllness(Illness illness);
    }
}
