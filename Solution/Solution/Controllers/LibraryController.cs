using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution.DAL;
using Solution.Models;

namespace Solution.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            List<Library> libraryList = Data.Get.Libraries.Include(lib => lib.ShelfList).ToList();
            return View();
        }
    }
}
