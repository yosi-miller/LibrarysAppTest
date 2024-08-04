using System.ComponentModel.DataAnnotations;

namespace Solution.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Height { get; set; }
        public int Width { get; set; }
        public Shelf Shelf { get; set; }
    }
}
