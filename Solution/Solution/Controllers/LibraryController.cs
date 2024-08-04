using Microsoft.AspNetCore.Mvc;

namespace Solution.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
