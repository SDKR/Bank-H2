<<<<<<< HEAD
﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
=======
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
>>>>>>> 565a004a0cb526df4bf7cb347546dbc16f243e23

//namespace H2_Case_Bank
//{
//    class DBAccount
//    {

<<<<<<< HEAD
//        public void Withdraw(int accountnumber, double transaction)
//        {
//            var connetionString = "Data Source=EVOPC18\\PMSMART;Initial Catalog=NORTHWND;User ID=test;Password=test";
//            var sql = "UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, Title = @Title ... ";// repeat for all variables
//            try
//            {
//                using (var connection = new SqlConnection(connetionString))
//                {
//                    using (var command = new SqlCommand(sql, connection))
//                    {
//                        command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = Lnamestring;
//                        command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = Fnamestring;
//                        command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Titelstring;
//                        // repeat for all variables....
//                        connection.Open();
//                        command.ExecuteNonQuery();
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                MessageBox.Show($"Failed to update. Error message: {e.Message}");
//            }
//        }
=======
        string constring = @"server=DESKTOP-5QOPHSN\SQLOPG;database=Bank;UID=sa;password=Wak40336";
        //Kims sql login
        //string constring = @"server=SKAB4-PC-01\KIM;database=Bank;UID=sa;password=Pa$$w0rd";
        //Kims sql login 
        //string constring = @"server=SKAB4-PC-03;database=Bank;UID=sa;password=Passw0rd";

        public void Withdraw(int accountnumber, double transaction)
        {

            SqlConnection sqlConn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("Select Balance from Account where PK_Accountnumber = "+ accountnumber +" ", sqlConn);
            sqlConn.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            sqlConn.Close();

            double currBalance = double.Parse(ds.Tables[0].Rows[0].ToString());
            Console.WriteLine(currBalance);

                /*
            var sql = "UPDATE Account SET = @LastName, FirstName = @FirstName, Title = @Title ... ";// repeat for all variables
            try
            {
                using (var connection = new SqlConnection(constring))
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = Lnamestring;
                        command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = Fnamestring;
                        command.Parameters.Add("@Title", SqlDbType.NVarChar).Value = Titelstring;
                        // repeat for all variables....
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to update. Error message: {e.Message}");
            }

            */
        }
>>>>>>> 565a004a0cb526df4bf7cb347546dbc16f243e23

//    }
//}
