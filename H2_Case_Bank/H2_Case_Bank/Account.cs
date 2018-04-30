using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Case_Bank
{
    class Account : Customer
    {

        DBAccount DBA = new DBAccount();

        public int Accountnumber { get; set; }
        public string Accounttype { get; set; }
        public double Interest { get; set; }
        public double Balance { get; set; }
        public string AccountCreation { get; set; }


        public void Deposit() //Find ud af hvad den skal tage i mod.
        {
            //YES!
        }

        public void Withdraw(int accountnumber, double transaction)
        {
            DBA.Withdraw(accountnumber, transaction);
        }

    }
}
