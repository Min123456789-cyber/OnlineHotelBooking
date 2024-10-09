using OnlineBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooking.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public RoomAvail Status { get; set; }

        public RoomViewModel()
        {

        }
        public RoomViewModel(Room model)
        {
            Id = model.Id;
            RoomNumber = model.RoomNumber;
            RoomTypeId = model.RoomTypeId;
            Status = model.Status;
        }

        public Room ConvertModel(RoomViewModel vm)
        {
            return new Room()
            {
                Id = vm.Id,
                RoomNumber = vm.RoomNumber,
                RoomTypeId = vm.RoomTypeId,
                Status = vm.Status,
            };
        }
    }
}
