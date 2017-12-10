using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using medDatabase.Domain.Models;
using medDatabase.Web.Contexts;
using medDatabase.Web.Models;

namespace medDatabase.Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly MedicalDatabaseContext _db;

        public RoomsController()
        {
            _db = new MedicalDatabaseContext();
        }

        public ActionResult Index()
        {
            var rooms = _db.Rooms.ToList();
            var patients = _db.Patients.ToList();
            var roomViewModels = CreateRoomViewModels(rooms, patients);
            return View(roomViewModels);
        }

        private static IEnumerable<RoomViewModel> CreateRoomViewModels(IList<Room> rooms, IList<Patient> patients)
        {
            var roomViewModels = new List<RoomViewModel>();
            foreach (var room in rooms)
            {
                var roomId = room.Id;
                var isOccupied = patients.Any(p => p.RoomId == roomId);
                var roomViewModel = new RoomViewModel
                {
                    RoomId = roomId,
                    IsOccupied = isOccupied
                };
                roomViewModels.Add(roomViewModel);
            }
            return roomViewModels;
        }
    }
}