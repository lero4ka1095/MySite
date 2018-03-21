using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGetLibrary
{
    public class Currency
    {
        [Key]
        public string IdCurrency { get; set; }
        public string NameCurrency { get; set; }
        public string CharCodeCurrency { get; set; }
        public int NumCodeCurrency { get; set; }

        public Currency(string id, string name, string code, int numCode)
        {
            IdCurrency = id;
            NameCurrency = name;
            CharCodeCurrency = code;
            NumCodeCurrency = numCode;
        }

        public Currency ()
        {

        }
    }
}