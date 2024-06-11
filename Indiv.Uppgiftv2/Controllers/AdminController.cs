using Microsoft.AspNetCore.Mvc;

namespace Indiv.Uppgiftv2.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
