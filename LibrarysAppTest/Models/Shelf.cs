using System.ComponentModel.DataAnnotations;

namespace LibrarysAppTest.Models
{
    public class Shelf
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="גובה מדף")]
        public int? ShelfHeight { get; set; }

        public List<Book>? ShelfsBooks { get; set; }
    }
}
