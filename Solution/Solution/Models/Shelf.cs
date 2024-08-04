using System.ComponentModel.DataAnnotations;

namespace Solution.Models
{
    public class Shelf
    {
        public Shelf()
        {
            Books = new List<Book>();
        }

        [Key]
        public int Id { get; set; }

        public int numShelf { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public Library Library { get; set; }

        public List<Book> Books { get; set; }
    }
}
