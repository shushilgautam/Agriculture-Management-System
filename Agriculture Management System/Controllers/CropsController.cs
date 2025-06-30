using Microsoft.AspNetCore.Mvc;

namespace Agriculture_Management_System.Controllers
{
    public class CropsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
