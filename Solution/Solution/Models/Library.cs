using System.ComponentModel.DataAnnotations;

namespace Solution.Models
{
    public class Library
    {
        public Library()
        {
            ShelfList = new List<Shelf>();
        }

        [Key]
        public int Id { get; set; }

        public string Genre { get; set; }

        public List<Shelf> ShelfList { get; set; }
    }
}
