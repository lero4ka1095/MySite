using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Class;
using System.Xml;

namespace ClassLibrary
{
    public static class LibraryRate
    {

        public static List<RateLib> getDailyExchange(DateTime date)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + date.ToString("dd'/'MM'/'yyyy"));
            XmlElement root = xml.DocumentElement;
            XmlNodeList nodesCurency = root.ChildNodes;
            List<RateLib> exchange_rates = new List<RateLib>();
            foreach (XmlNode nodeCurency in nodesCurency)
            {
                RateLib er = new RateLib();
                er.Currency = nodeCurency["CharCode"].InnerText;
                int nominal = Convert.ToInt32(nodeCurency["Nominal"].InnerText);
                double value = Convert.ToDouble(nodeCurency["Value"].InnerText);
                er.Value = (float)value / nominal;
                er.Date = date;
                exchange_rates.Add(er);
            }
            return exchange_rates;
        }
    }
}
