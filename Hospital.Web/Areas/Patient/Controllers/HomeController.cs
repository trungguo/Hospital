using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Test.Controllers
{
    [Area("Patient")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
