using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Case_Bank
{
    class Customer
    {

        DBCustomer DBC = new DBCustomer();

        public int UserID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime CreationDate { get; set; }

        public void CreateCustomer(string firstname, string lastname)
        {
            DBC.createCustomer(firstname, lastname);
        }

        public void DeleteCustomer(int UserID)
        {
            //Delete Customer
        }

        public void CreateAccount(string firstname, string lastname)
        {
            // Do something
        }

        public void CreateAccount(int Accountnumber, string AccountType, float Interest, float Balance, DateTime Dato)
        {
            // Gør noget for fanden!
        }

        public List<Customer> ReturnCustomers()
        {
            List<Customer> cslist = DBC.returnCustomers();
            return cslist;
        }
    }
}
