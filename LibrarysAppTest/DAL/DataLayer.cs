using LibrarysAppTest.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarysAppTest.DAL
{
    // DbContext קלאס שמייצג את שכבת הנתונים יורש מקלאס בשם
    public class DataLayer : DbContext
    {
        // קונסטרקטור שמקבל מחרוזרת חיבור ומעביר אותה לקונסטרקטור של קלאס האב
        public DataLayer(string connectionString) : base(GetOptions(connectionString))
        {
            Database.EnsureCreated();

            // להכניס  ספרייה לטבלה אם אין עדיין ספרייה
            Sead();
        }

        private void Sead()
        {
            // אם קיים חברים תחזור
            if (Librarys.Count() > 0)
                return;

            // אם לא קיים תיצור ותכניס ערכים לטבלה
            Library firstLibrary = new Library
            {
                LibraryType = "תורה"
            };
            // מחזיר את הערך הראשון שנוצר לתוך טבלת החברים
            Librarys.Add(firstLibrary);
            SaveChanges();

        }

        public DbSet<Library> Librarys { get; set; }

        // פונקציה שמחזירה את אפשרויות התחברות למסד נתונים
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}
