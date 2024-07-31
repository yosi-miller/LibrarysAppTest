﻿using System.ComponentModel.DataAnnotations;

namespace LibrarysAppTest.Models
{
    public class Library
    {
        [Key]
        public int Id { get; set; }
        
        //  זאנר של הספרייה
        [Display(Name ="מחלקה")]
        public string? LibraryType { get; set; }

        // מערך שיחזיק את כל המדפים של הספרייה
        public List<Shelf>? Shelfs { get; set; }
    }
}