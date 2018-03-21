using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGetLibrary
{
    public partial class SqlRepository
    {
        public bool insertCurrencies(List<Currency> cur)
        {
            List<Currency> curDB = new List<Currency>();
            curDB = Db.Currencies.ToList<Currency>();
            foreach(Currency c in cur)
            {
                if(curDB.FindLastIndex(a => a.IdCurrency == c.IdCurrency) < 0)
                {
                    if(!insertCurrency(c))
                        return false;
                }
                else
                {
                    //Db.Currencies.
                    Db.SaveChanges();
                }

            }
            return true;
        }

        public bool insertCurrency(Currency cur)
        {
            try
            {
                Db.Currencies.Add(cur);
                Db.SaveChanges();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public Currency getCurrency(string IdCurrency)
        {
            Currency cur = new Currency();
            cur = Db.Currencies.FirstOrDefault(d => d.IdCurrency == IdCurrency);
            return cur;
        }

        public List<Currency> getCurencies()
        {
            DatabaseContext db = new DatabaseContext();
            return db.Currencies.ToList<Currency>();
        }
    }
}
