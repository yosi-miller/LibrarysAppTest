using Microsoft.EntityFrameworkCore;
using Solution.Models;

namespace Solution.DAL
{
    public class DataLayer : DbContext
    {
        //קונסקטרקטור שמקבל את הסטרינג של החיבור לדאטא בייס ומעביר אותו לקונסטרקטור האב
        public DataLayer(string connectionString) : base(GetOptions(connectionString))
        {
            //מוודא שנוצר דאטא בייס
            Database.EnsureCreated();

            //להכניס נתונים ראשוניים לדאטא בייס
            Sead();
        }

        private void Sead()
        {

            //הנתונים יכנסו רק אם הטבלה ריקה
            if (!Libraries.Any())
            {
                Library library = new Library { Genre = "fantazy" };

                library.ShelfList = CreateDefaultSHelfList(library);
                Libraries.Add(library);
                SaveChanges();

            }

        }
        private List<Shelf> CreateDefaultSHelfList(Library library)
        {
            List<Shelf> shelfList = new List<Shelf>();

            Shelf shelf = new Shelf { Height = 50, Width = 100, Library = library };

            shelf.Books = CreateDefaultBookList(shelf);
            shelfList.Add(shelf);
            Shelfes.Add(shelf);

            return shelfList;
        }
        private List<Book> CreateDefaultBookList(Shelf shelf)
        {
            List<Book> bookList = new List<Book>();
            Book book = new Book { Height = 10, Width = 10, Title = "hery poter", Shelf = shelf };
            bookList.Add(book);
            Books.Add(book);
            return bookList;
        }

        public DbSet<Library> Libraries { get; set; }
        public DbSet<Shelf> Shelfes { get; set; }
        public DbSet<Book> Books { get; set; }



        //פונקצייה שמחזירה את האפשרויות חיבור לדאטא בייס
        //הפונקצייה מוגדרת סטטיק כדי שנוכל להשתמש איתה ללא יצירת מופע חדש של הקלאס
        public static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions
                .UseSqlServer(new DbContextOptionsBuilder(), connectionString)
                .Options;
        }
    }
}
