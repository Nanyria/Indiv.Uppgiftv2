using Microsoft.AspNetCore.Mvc;

namespace Indiv.Uppgiftv2.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
