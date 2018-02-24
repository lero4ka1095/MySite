using System;

namespace ClassLibrary.Class
{

    public class RateLib
    {
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public RateLib(string currency, DateTime date, double value)
        {
            this.Currency = currency;
            this.Date = date;
            this.Value = value;
        }

        public RateLib()
        {
        }

        public void getTestRate()
        {
            this.Currency = "USD";
            this.Date = DateTime.Today;
            this.Value = 68.9;
        }
    }
}
