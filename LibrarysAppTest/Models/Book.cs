using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarysAppTest.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "שם הספר")]
        public string? BookName { get; set; }

        [Display(Name = "מחלקה"), NotMapped]
        public string? BookType { get; set; }

        [Display(Name = "גובה הספר")]
        public int BookHeight { get; set; }
        public Shelf? CurentShelf { get; set; }

        //[Display(Name = "רוחב הספר")]
        //public int BookWidth { get; set; }
    }   
}
