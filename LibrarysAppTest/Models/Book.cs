using System.ComponentModel.DataAnnotations;

namespace LibrarysAppTest.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "מחלקה")]
        public string? BookType { get; set; }

        [Display(Name = "גובה הספר")]
        public int BookHeight { get; set; }

        [Display(Name = "רוחב הספר")]
        public int BookWidth { get; set; }


    }
}
