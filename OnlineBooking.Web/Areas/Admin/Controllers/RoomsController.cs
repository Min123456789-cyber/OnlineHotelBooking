using Microsoft.AspNetCore.Mvc;
using OnlineBooking.Services;

namespace OnlineBooking.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomsController : Controller
    {
        private IRoomService _rooms;

        public RoomsController(IRoomService rooms)
        {
            _rooms = rooms;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
