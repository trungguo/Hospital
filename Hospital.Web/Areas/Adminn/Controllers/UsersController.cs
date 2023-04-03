using Microsoft.AspNetCore.Mvc;
using Hospital.Service;

namespace Hospital.Web.Areas.Adminn.Controllers
{
    [Area("Adminn")]
    public class UsersController : Controller

    {
        private IApplicationUserService _userService;
        public UsersController(IApplicationUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index(int PageNumber=1, int PageSize=10)
        {
            return View(_userService.GetAll(PageNumber,PageSize));
        }
        public IActionResult AllDoctors(int PageNumber = 1, int PageSize = 10)
        {
            return View(_userService.GetAllDoctor(PageNumber, PageSize));
        }
    }
}
