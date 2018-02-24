using System;
using ClassLibrary.Class;
using System.Collections.Generic;

namespace MySite.Models
{

    public class Rate
    {
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public Rate(string currency, DateTime date, double value)
        {
            this.Currency = currency;
            this.Date = date;
            this.Value = Math.Round(value,2);
        }

        public Rate()
        {
        }

        public void getTestRate()
        {
            this.Currency = "USD";
            this.Date = DateTime.Today;
            this.Value = 68.9;
        }

        public Rate getRateLibToRate(RateLib lib)
        {
            return new Rate(lib.Currency, lib.Date, lib.Value);
        }

        public List<Rate> getListRateLibToListRate(List<RateLib> lib)
        {
            List<Rate> lr = new List<Rate>();
            foreach(RateLib rl in lib)
            {
                lr.Add(getRateLibToRate(rl));
            }
            return lr;
        }
    }
}
