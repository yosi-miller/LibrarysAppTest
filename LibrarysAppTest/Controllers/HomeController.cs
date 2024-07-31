using LibrarysAppTest.DAL;
using LibrarysAppTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LibrarysAppTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // הפנייה לדף של כל הספריות
        public IActionResult ShowAllLibrarys()
        {
            List<Library> librarysList = Data.Get.Librarys.ToList();
            return View(librarysList);
        }

        // פונקציה שתפנה לטופס הוספת ספרייה חדשה
        public IActionResult CreateNewLibrary() 
        { 
            return View(new Library());
        }

        // פונקציה שתוסיף ספרייה חדשה
		[HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddNewLibrary(Library library)
        {
            if (library == null)
            {
                return NotFound();
            }
            Data.Get.Librarys.Add(library);
            Data.Get.SaveChanges();
            return RedirectToAction("ShowAllLibrarys");
        }

        // פונקציה שמציגה את כל המדפים של ספר מסוים
        public IActionResult ShowAllShelf(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ShowAllLibrarys");
            }

            List<Shelf> shelfsList = Data.Get.Shelfs.ToList().FindAll(shelf => shelf.CurentLibrary.Id == id);
           
            if (id == null)
            {
                return RedirectToAction("ShowAllLibrarys");
            }

            return View(shelfsList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
