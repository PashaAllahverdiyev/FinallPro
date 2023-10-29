using Microsoft.AspNetCore.Mvc;

namespace Hotel.UI.Areas.Admin.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
