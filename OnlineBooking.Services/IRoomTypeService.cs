using OnlineBooking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooking.Services
{
    public interface IRoomTypeService
    {
        IEnumerable<RoomTypeViewModel> GetAllRoomTypes();

        RoomTypeViewModel GetRoomType(int TypeId);
        void UpdateRoomType(RoomTypeViewModel roomType);
        void InsertRoomType(RoomTypeViewModel roomType);
        void DeleteRoomType(int id);
    }
}
