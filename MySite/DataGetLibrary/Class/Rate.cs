using System;

namespace DataGetLibrary
{

    public class Rate
    {
        public Currency Currency { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public Rate(Currency currency, DateTime date, double value)
        {
            this.Currency = currency;
            this.Date = date;
            this.Value = value;
        }

        public Rate()
        {
        }

        public void getTestRate()
        {
            //this.Currency = "USD";
            this.Date = DateTime.Today;
            this.Value = 68.9;
        }

        public string getStringDate()
        {
            return Date.ToString("dd/MM/yyyy");
        }

        public double getValue()
        {
            return Math.Round(Value, 2);
        }
    }
}
