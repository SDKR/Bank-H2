using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Case_Bank
{
    class Transaction : IDBTransactions
    {

        DBTransaction dbt = new DBTransaction();

        public int TransactionID { get; set; }
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        
        public List<Transaction> getTransactions(Account acc)
        {
            return dbt.getTransactions(acc);
        }
        
    }
}
