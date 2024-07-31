using System.ComponentModel.DataAnnotations;

namespace LibrarysAppTest.Models
{
    public class Shelf
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="גובה מדף")]
        public int? ShelfHeight { get; set; }

        // TODO - לגשת למידע של הז'אנר (לכאורה מתוך מהמשתנה שמכיל את ההפניה לארון ספרים) ולהחליט אם להוסיף לעשות בגט 
        //זאנר של הספרייה
        [Display(Name = "מחלקה")]
        public string? LibrarysShelfType { get; set; }

        public Library? CurentLibrary { get; set; }
    }
}
