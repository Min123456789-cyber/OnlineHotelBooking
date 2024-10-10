using Microsoft.AspNetCore.Mvc;
using OnlineBooking.Services;
using OnlineBooking.Utility;
using OnlineBooking.ViewModels;

namespace OnlineBooking.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomTypeController : Controller
    {
        private IRoomTypeService _roomType;

        public RoomTypeController(IRoomTypeService roomType)
        {
            _roomType = roomType;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            PagedResult<RoomTypeViewModel> vm = _roomType.GetAllRoomTypes(pageNumber, pageSize);
            return View(vm);    
        }
    }
}
