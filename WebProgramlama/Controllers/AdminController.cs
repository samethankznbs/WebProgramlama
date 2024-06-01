using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace yazlabyeto.Controllers
{
    [Authorize(Roles = "ADMİN")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult AdminNavbar()
        {
            return PartialView();
        }

    }
}
