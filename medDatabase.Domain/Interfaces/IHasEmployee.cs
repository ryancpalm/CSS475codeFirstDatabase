using medDatabase.Domain.Models;

namespace medDatabase.Domain.Interfaces
{
    public interface IHasEmployee
    {
        int GetEmployeeId();
        void SetEmployee(Employee employee);
    }
}
