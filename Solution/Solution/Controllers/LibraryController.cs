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
            return View(libraryList);
        }

        // Get Library/Create
        public IActionResult Create()
        {
            return View();
        }

        // Post Library/Create
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Library library)
        {
            if (library == null)
            {
                return BadRequest();
            }
            Data.Get.Libraries.Add(library);
            Data.Get.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // Get Library/AddShelf
        public IActionResult AddShelf(int libraryId) 
        {
            Library? library = Data.Get.Libraries.FirstOrDefault(lib => lib.Id == libraryId);

            if (library == null)
            {
                return NotFound();
            }

            Shelf shelf = new Shelf { Library = library };
            return View(shelf);
        }

		// Get Library/Details/:id
		public IActionResult Details(int id)
		{
            Library? library = Data.Get.Libraries.
                Include(lib => lib.ShelfList).
                ThenInclude(shelf => shelf.Books).
                FirstOrDefault(library => library.Id == id);
			return View(library);
		}

        // Post Library/AddShelf
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddShelf(Shelf shelf)
        {
            Library? library = Data.Get.Libraries.FirstOrDefault(library => library.Id == shelf.Library.Id);

            if (library == null)
            {
                return NotFound();
            }

            shelf.Library = library;
            Data.Get.Shelfes.Add(shelf);
            Data.Get.SaveChanges();

            return RedirectToAction(nameof(Details), new {id = shelf.Library.Id});
        }
	}
}
