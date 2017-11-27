using medDatabase.Domain.Models;
using medDatabase.Populater.Interfaces;

namespace medDatabase.Populater.Mockaroo.Models
{
    public class MockarooRoom : IMockarooConvertible<Room>
    {
        public int Id { get; set; }

        public Room Convert()
        {
            var room = new Room { Id = Id };
            return room;
        }
    }
}
