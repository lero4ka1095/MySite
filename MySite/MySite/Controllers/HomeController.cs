using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySite.Models;
using ClassLibrary;

namespace MySite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Rate()
        {
            List<string> l = new List<string>();
            l.Add("USD");
            l.Add("KGS");
            l.Add("EUR");
            List<Rate> rates = new List<Rate>();
            Rate r = new Rate();
            rates = r.getListRateLibToListRate(LibraryRate.getDailyExchange(DateTime.Today));
            List<Rate> filteredList = rates.Where(a => a.Currency == l.FindLast(m => m == a.Currency)).ToList();
            filteredList.Sort((a, b) => a.Currency.CompareTo(b.Currency));
            ViewBag.Date = DateTime.Today.ToString("dd/MM/yyyy");
            return View(filteredList);
        }
    }
}