using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGetLibrary.Models
{
    public class Currency
    {
        [Key]
        public string IdCurrency { get; set; }
        public string DescriptionCurrency { get; set; }

        public Currency (string id, string description)
        {
            IdCurrency = id;
            DescriptionCurrency = description;
        }

        public Currency ()
        {

        }
    }
}