using medDatabase.Domain.Models;

namespace medDatabase.Domain.Interfaces
{
    public interface IHasRoom
    {
        int GetRoomId();
        void SetRoom(Room room);
    }
}
