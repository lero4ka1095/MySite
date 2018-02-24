using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Class;
using ClassLibrary;
using DataGetLibrary;
using DataGetLibrary.Models;
using System.Data.Entity;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*RateLib rate = new RateLib();
            rate.Currency = "USD";
            rate.Date = DateTime.Today;
            rate.Value = 68.9;
            DateTime date = new DateTime();
            date = DateTime.Today;
            Console.WriteLine(date.ToString("dd'/'MM'/'yyyy"));
            List<RateLib> rates = new List<RateLib>();
            rates = LibraryRate.getDailyExchange(DateTime.Today);*/

            DBaseContext db = new DBaseContext();
            Console.WriteLine("1");
            try
            {
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            db.Currency.Add(new Currency("KGS", "KGS"));
            db.SaveChanges();
            Console.WriteLine("2");
            IEnumerable<Currency> b = db.Currency;
            List<Currency> list = b.ToList<Currency>();
            Console.WriteLine("3");
            Console.WriteLine(list.Count);
            foreach(Currency cur in list)
            {
                Console.WriteLine(cur.IdCurrency);
            }
            Console.WriteLine("4");
            Console.ReadKey();


        }

    }
}
