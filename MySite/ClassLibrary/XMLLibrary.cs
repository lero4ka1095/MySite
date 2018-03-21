using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using DataGetLibrary;
using System.Xml;

namespace ClassLibrary
{
    public static class XmlLibrary
    {

        public static List<Rate> getDailyExchange(DateTime date)
        {
            XmlDocument xml = new XmlDocument();
            List<Rate> exchange_rates = new List<Rate>();
            try
            {
                xml.Load("http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + date.ToString("dd'/'MM'/'yyyy"));
            }
            catch(Exception ex)
            {
                return exchange_rates;
            }
            XmlElement root = xml.DocumentElement;
            XmlNodeList nodesCurency = root.ChildNodes;
            
            SqlRepository sql = new SqlRepository();
            foreach (XmlNode nodeCurency in nodesCurency)
            {
                Rate er = new Rate();
                er.Currency = sql.getCurrency(nodeCurency.Attributes["ID"].Value);
                int nominal = Convert.ToInt32(nodeCurency["Nominal"].InnerText);
                double value = Convert.ToDouble(nodeCurency["Value"].InnerText);
                er.Value = (float)value / nominal;
                er.Date = date;
                exchange_rates.Add(er);
            }
            return exchange_rates;
        }

        public static List<Rate> getCurrencyExchange(DateTime startDate, DateTime endDate, string idCurrency)
        {
            XmlDocument xml = new XmlDocument();
            SqlRepository sql = new SqlRepository();
            Currency currency = sql.getCurrency(idCurrency);
            List<Rate> exchange_rates = new List<Rate>();
            if (idCurrency == null)
                return new List<Rate>();
            try
            {
                xml.Load("http://www.cbr.ru/scripts/XML_dynamic.asp?date_req1=" + startDate.ToString("dd'/'MM'/'yyyy")
                                                                + "&date_req2="
                                                                + endDate.ToString("dd'/'MM'/'yyyy")
                                                                + "&VAL_NM_RQ="
                                                                + idCurrency.Substring(0, 6));
            }
            catch (Exception ex)
            {
                return exchange_rates;
            }
            XmlElement root = xml.DocumentElement;
            XmlNodeList nodesCurency = root.ChildNodes;
            foreach (XmlNode nodeCurency in nodesCurency)
            {
                Rate er = new Rate();
                er.Currency = currency;
                int nominal = Convert.ToInt32(nodeCurency["Nominal"].InnerText);
                double value = Convert.ToDouble(nodeCurency["Value"].InnerText);
                er.Value = (float)value / nominal;
                er.Date = Convert.ToDateTime(nodeCurency.Attributes["Date"].Value);
                exchange_rates.Add(er);
            }
            return exchange_rates;
        }

        public static void uploadCurrency()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("http://www.cbr.ru/scripts/XML_daily.asp?date_req=" + DateTime.Today.ToString("dd'/'MM'/'yyyy"));
            XmlElement root = xml.DocumentElement;
            XmlNodeList nodesCurency = root.ChildNodes;
            List<Currency> xmlCurrency = new List<Currency>();
            foreach (XmlNode nodeCurency in nodesCurency)
            {
                Currency cur = new Currency();
                cur.CharCodeCurrency = nodeCurency["CharCode"].InnerText;
                cur.NumCodeCurrency = Convert.ToInt32(nodeCurency["NumCode"].InnerText);
                cur.NameCurrency = nodeCurency["Name"].InnerText;
                cur.IdCurrency = nodeCurency.Attributes["ID"].Value;
                xmlCurrency.Add(cur);
            }
            SqlRepository sql = new SqlRepository();
            sql.insertCurrencies(xmlCurrency);
        }
    }
}
