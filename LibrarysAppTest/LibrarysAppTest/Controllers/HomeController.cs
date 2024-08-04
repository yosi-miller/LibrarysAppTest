using LibrarysAppTest.DAL;
using LibrarysAppTest.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

            List<Shelf> shelfsList = Data.Get.Shelfs.ToList().FindAll(shelf => shelf.CurentLibrary.Id == id);

            if (id == null)
            {
                return RedirectToAction("ShowAllLibrarys");
            }

            return View(shelfsList);
        }

        // ������� ������ ��� ����� ��� ���
        public IActionResult CreateNewShelf(int id)
        {
            return View();
        }

        // ������� ������ ��� ���
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddNewShelf(Shelf shelf)
        {
            if (shelf == null)
            {
                return NotFound();
            }

            Shelf newShelf = new Shelf
            {
                ShelfHeight = shelf.ShelfHeight,
                CurentLibrary = Data.Get.Librarys.FirstOrDefault(l => l.Id == shelf.Id),
            };

            if (newShelf == null)
                return NotFound();

            Data.Get.Shelfs.Add(newShelf);
            Data.Get.SaveChanges();

            return RedirectToAction("ShowAllLibrarys");

        }

        // �������� ����� �� �� ������ ������� ���� ������ ��'��� �����
        public IActionResult ShowAllBooks(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ShowAllLibrarys");
            }

            List<Book> booksList = Data.Get.Books.ToList().FindAll(book => book.CurentShelf.Id == id);

            if (id == null)
            {
                return RedirectToAction("ShowAllLibrarys");
            }

            return View(booksList);
        }

        // ������� ������ ��� ����� ��� ���
        public IActionResult CreateNewBook(int id)
        { 
            return View();
        }


        // ������� ������ ��� ���
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddNewBook(Book book)
        {
            if (book == null)
            {
                return NotFound();
            }

            Shelf thisShelf = Data.Get.Shelfs.FirstOrDefault(s => s.Id == book.Id);

            if (book.BookHeight > thisShelf.ShelfHeight)
                return BadRequest("���� ���� ����� ����");

            if (book.BookType != thisShelf.CurentLibrary.LibraryType)
                return BadRequest("����� ����� �� �����");

            Book newBook = new Book
            {
                BookName = book.BookName,
                BookHeight = book.BookHeight,
                CurentShelf = Data.Get.Shelfs.FirstOrDefault(s => s.Id == book.Id),
                //ShelfHeight = shelf.ShelfHeight,
                //CurentLibrary = Data.Get.Librarys.FirstOrDefault(l => l.Id == shelf.Id),
            };

            if (newBook == null)
                return NotFound();

            Data.Get.Books.Add(newBook);
            Data.Get.SaveChanges();

            return RedirectToAction("ShowAllLibrarys");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
