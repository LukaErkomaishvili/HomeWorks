using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    public class Card
    {
        public string CardNumber { get; set; }
        public string Expiry { get; set; }
        public string Pin { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public string Owner { get; set; }
    }
}
