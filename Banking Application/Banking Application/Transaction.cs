using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string CardNumber { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public decimal BalanceAfter { get; set; }
    }
}
