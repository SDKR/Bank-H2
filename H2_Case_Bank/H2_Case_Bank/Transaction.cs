using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Case_Bank
{
    class Transaction : Account
    {
        public int TransactionID { get; set; }
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public string Date { get; set; }
        public double Amount { get; set; }

        public string Print()
        {
            return "hej"; //her skal der skrives noget.
        }

    }
}
