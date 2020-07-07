using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyWeb.Models
{
    public class CurrencyViewModel
    {
        public CurrencyGrouped CurrencyGroupedBy5Minutes { get; set; }
        public CurrencyGrouped CurrencyGroupedBy15Minutes { get; set; }
        public CurrencyGrouped CurrencyGroupedBy30Minutes { get; set; }
        public CurrencyGrouped CurrencyGroupedBy1Hour { get; set; }
    }
}
