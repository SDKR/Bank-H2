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
        public decimal Interest { get; set; }
        public decimal Balance { get; set; }
        public DateTime AccountCreation { get; set; }

        public List<Account> getCustomerAccounts(Customer cus)
        {
            return DBA.getAccounts(cus.UserID);
        }


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
