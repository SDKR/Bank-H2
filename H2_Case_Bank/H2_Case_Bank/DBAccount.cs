using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace H2_Case_Bank
{
    class DBAccount
    {

        string constring = @"server=DESKTOP-5QOPHSN\SQLOPG;database=Bank;UID=sa;password=Wak40336";
        //Kims sql login
        //string constring = @"server=SKAB4-PC-01\KIM;database=Bank;UID=sa;password=Pa$$w0rd";
        //Kims sql login 
        //string constring = @"server=SKAB4-PC-03;database=Bank;UID=sa;password=Passw0rd";

        public void Withdraw(int accountnumber, double transaction)
        {

            // Get account balance
            SqlConnection sqlConn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("Select Balance from Account where PK_Accountnumber = "+ accountnumber +" ", sqlConn);
            sqlConn.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            sqlConn.Close();

            double currBalance = double.Parse(ds.Tables[0].Rows[0].ToString());
            Console.WriteLine("Current balacne" + currBalance);

            // Make balance calculation
            currBalance = currBalance - transaction;

            // Update balance 
            var sql = "UPDATE Account SET Balance = @Balance where PK_Accountnumber = @PK_Accountnumber";
            try
            {
                using (var connection = new SqlConnection(constring))
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@Balance", SqlDbType.Float).Value = currBalance;
                        command.Parameters.Add("@PK_Accountnumber", SqlDbType.Int).Value = accountnumber;
                        // repeat for all variables....
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to withdraw. Error message: {e.Message}");
            }


        }

   }
}
