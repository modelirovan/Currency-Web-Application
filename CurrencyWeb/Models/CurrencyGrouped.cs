using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyWeb.Models
{
    public class CurrencyGrouped
    {
        public int GroupedByMinuts { get; set; }
        public string CurrencyCode { get; set; }
        public decimal MaxRate { get; set; }
        public decimal MinRate { get; set; }
        public decimal FirstRate { get; set; }
        public decimal LastRate { get; set; }
    }
}
