using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataGetLibrary;
using ClassLibrary;
using Newtonsoft.Json;

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
        
        [HttpGet]
        public ActionResult Rate()
        {
            /*List<string> l = new List<string>();
            l.Add("USD");
            l.Add("KGS");
            l.Add("EUR");*/
            List<Rate> rates = new List<Rate>();
            rates = XmlLibrary.getDailyExchange(DateTime.Today).ToList<Rate>();
            //List<Rate> filteredList = rates.Where(a => a.Currency.CharCodeCurrency == l.FindLast(m => m == a.Currency.CharCodeCurrency)).ToList();
            rates.Sort((a, b) => a.Currency.CharCodeCurrency.CompareTo(b.Currency.CharCodeCurrency));
            ViewBag.Date = DateTime.Today.ToString("dd/MM/yyyy");
            /*SqlRepository sql = new SqlRepository();
            List<Currency> cur = new List<Currency>();
            cur = sql.getCurencies();
            cur.Sort((a, b) => a.CharCodeCurrency.CompareTo(b.CharCodeCurrency));
            SelectList listCurrencies = new SelectList(cur, "IdCurrency", "CharCodeCurrency");
            ViewBag.listCurrencies = listCurrencies;*/
            return View(rates);
        }

       [HttpGet]
        public ActionResult CurrencyRate(string Currency, DateTime StartDate, DateTime EndDate)
        {
           ViewBag.StartDate = StartDate.ToString("dd/MM/yyyy");
           ViewBag.EndDate = EndDate.ToString("dd/MM/yyyy");
           List<Rate> rates = new List<Rate>();
           rates = XmlLibrary.getCurrencyExchange(StartDate, EndDate, Currency).ToList<Rate>();
           ViewBag.Currency = rates.FirstOrDefault().Currency;
           ViewBag.DataPoints = JsonConvert.SerializeObject(ConvertLibrary.getDatePoint(rates));
           ViewBag.Title = "Курс валют";
           return View(rates);
        }

       public ActionResult Rates()
       {
           SqlRepository sql = new SqlRepository();
           List<Currency> currencies = new List<Currency>();
           currencies = sql.getCurencies();
           currencies.Sort((a, b) => a.CharCodeCurrency.CompareTo(b.CharCodeCurrency));
           SelectList listCurrencies = new SelectList(currencies, "IdCurrency", "CharCodeCurrency");
           MultiSelectList mlistCurrencies = new MultiSelectList(currencies, "IdCurrency", "CharCodeCurrency");
           ViewBag.listCurrencies = listCurrencies;
           ViewBag.mlistCurrencies = mlistCurrencies;
           return View();
       }

       [HttpGet]
       public ActionResult DateRate(DateTime Date)
       {
           List<Rate> rates = new List<Rate>();
           rates = XmlLibrary.getDailyExchange(Date);
           rates.Sort((a, b) => a.Currency.CharCodeCurrency.CompareTo(b.Currency.CharCodeCurrency));
           ViewBag.Date = Date.ToString("dd/MM/yyyy");
           ViewBag.DataPoints = JsonConvert.SerializeObject(ConvertLibrary.getStringPoint(rates));
           ViewBag.Title = "Курс валют";
           return View(rates);
       }

       [HttpGet]
       public ActionResult CurrencyDateRate(DateTime Date, List<string> Currencies)
       {
           List<Rate> rates = new List<Rate>();
           rates = XmlLibrary.getDailyExchange(Date).ToList<Rate>();
           List<Rate> filteredList = rates.Where(a => a.Currency.IdCurrency == Currencies.FindLast(m => m == a.Currency.IdCurrency)).ToList();
           filteredList.Sort((a, b) => a.Currency.CharCodeCurrency.CompareTo(b.Currency.CharCodeCurrency));
           ViewBag.DataPoints = JsonConvert.SerializeObject(ConvertLibrary.getStringPoint(filteredList));
           ViewBag.Date = Date.ToString("dd/MM/yyyy");
           return View(filteredList);
       }

        
    }
}