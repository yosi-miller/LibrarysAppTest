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

        // ������ ��� �� �� �������
        public IActionResult ShowAllLibrarys()
        {
            List<Library> librarysList = Data.Get.Librarys.ToList();
            return View(librarysList);
        }

        // ������� ����� ����� ����� ������ ����
        public IActionResult CreateNewLibrary() 
        { 
            return View(new Library());
        }

        // ������� ������ ������ ����
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

        // ������� ������ �� �� ������ �� ��� �����
        public IActionResult ShowAllShelf(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ShowAllLibrarys");
            }

            Library? library = Data.Get.Librarys.Include(li => li.Shelfs).FirstOrDefault(li => li.Id == id);

            if (id == null)
            {
                return RedirectToAction("ShowAllLibrarys");
            }

            return View(library);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
