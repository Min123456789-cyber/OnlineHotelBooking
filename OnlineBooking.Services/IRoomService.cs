using OnlineBooking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooking.Services
{
    public interface IRoomService
    {
        IEnumerable<RoomViewModel> GetAll();
        RoomViewModel GetRoom(int Id);
        void UpdateRoom(RoomViewModel room);
        void InsertRoom(RoomViewModel room);
        void DeleteRoom(int id);
    }
}
