using DataGetLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class ConvertLibrary
    {
        public static List<DataPoint> getDatePoint (List<Rate> rates)
        {
            List<DataPoint> dpoints = new List<DataPoint>();
            foreach(Rate rate in rates)
            {
                DataPoint dp = new DataPoint(rate.getStringDate(), rate.Value);
                dpoints.Add(dp);
            }
            return dpoints;
        }

        public static List<DataPoint> getStringPoint(List<Rate> rates)
        {
            List<DataPoint> dpoints = new List<DataPoint>();
            foreach (Rate rate in rates)
            {
                DataPoint dp = new DataPoint(rate.Currency.CharCodeCurrency, rate.Value);
                dpoints.Add(dp);
            }
            return dpoints;
        }
    }
}
