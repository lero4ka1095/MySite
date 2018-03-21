using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using DataGetLibrary;
using System.Data.Entity;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseContext db = new DatabaseContext();
            User admin = db.Users.First();
            User admin2 = new User("admin2", "admin2", "Administrator", DateTime.Parse("28.10.1995"),"A");
            db.Users.Add(admin2);
            db.SaveChanges();
            admin2 = db.Users.Where(a => a.login == "admin2").First();
            Note note = db.Notes.First();
            Commentary com = new Commentary("CommentaryTextTest", admin2, note);
            db.Commentaries.Add(com);
            db.SaveChanges();
            Console.WriteLine("Ok");
            Console.ReadKey();
        }

    }
}
