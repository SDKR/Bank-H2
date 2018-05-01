﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace H2_Case_Bank
{
    class DBAccount
    {
        NumberFormatInfo remove2 = new NumberFormatInfo();
        

        public List<Account> getAccounts(int custumerID)
        {
            ////remove2.CurrencyDecimalDigits = 2;
            ////remove2.NumberDecimalDigits = 2;
            List<Account> CusList = new List<Account>();

            SqlConnection sqlConn = new SqlConnection(DatabaseLogin.constring);
            SqlCommand cmd = new SqlCommand("Select * from Account where FK_CustomerID = "+custumerID+"", sqlConn);
            sqlConn.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            sqlConn.Close();

            var empList = ds.Tables[0].AsEnumerable().Select(dataRow => new Account {
                Accountnumber = dataRow.Field<int>("PK_Accountnumber"),
                Accounttype = dataRow.Field<string>("AccountType"),
                Interest = dataRow.Field<decimal>("Interest"),
                Balance = dataRow.Field<decimal>("Balance"),
                AccountCreation = dataRow.Field<DateTime>("CreationDate"),
                FK_CustomerID = dataRow.Field<int>("FK_CustomerID")
            }).ToList();

            for (int i = 0; i < empList.Count; i++)
            {
                Console.WriteLine(empList[i].Accountnumber);
                Console.WriteLine(empList[i].Accounttype);
                Console.WriteLine(empList[i].Interest);
                Console.WriteLine(empList[i].Balance);
                Console.WriteLine(empList[i].AccountCreation);
                Console.WriteLine(empList[i].FK_CustomerID);
                Console.WriteLine();
            }
            //Customer Cus = new Customer(ds.Tables[0].Rows[0], );

            // CusList.Add()
            //Console.WriteLine(ds.GetXml());
            //string LoginInfo = ds.Tables[0].Rows[0]["Brugertype"].ToString();

            return empList;
        }

        public void createAccount(Account acc)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseLogin.constring))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    // Creates todays date for fussy Mr. database
                    String formatsdate = @"MM\/dd\/yyyy HH:mm";
                    DateTime localDate = DateTime.Now;
                    var cultureInfo = new CultureInfo("fr-FR");
                    string today = localDate.ToString(formatsdate);

                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT into Account (AccountType, Interest, Balance, CreationDate, FK_CustomerID) VALUES (@AccountType, @Interest, @Balance, @CreationDate, @FK_CustomerID)";
                    command.Parameters.AddWithValue("@AccountType", acc.Accounttype);
                    command.Parameters.AddWithValue("@Interest", acc.Interest);
                    command.Parameters.AddWithValue("@Balance", acc.Balance);
                    command.Parameters.AddWithValue("@CreationDate", today);
                    command.Parameters.AddWithValue("@FK_CustomerID", acc.FK_CustomerID);
                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        // error here
                        Console.WriteLine("Create account Error");
                        Console.WriteLine(e);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void Withdraw(int accountnumber, decimal transaction)
        {

            // Get account balance
            SqlConnection sqlConn = new SqlConnection(DatabaseLogin.constring);
            SqlCommand cmd = new SqlCommand("Select Balance from Account where PK_Accountnumber = "+ accountnumber +" ", sqlConn);
            sqlConn.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            sqlConn.Close();

            decimal currBalance = decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
            Console.WriteLine("Current balacne" + currBalance);

            // Make balance calculation
            currBalance = currBalance - transaction;

            // Update balance 
            var sql = "UPDATE Account SET Balance = @Balance where PK_Accountnumber = @PK_Accountnumber";
            try
            {
                using (var connection = new SqlConnection(DatabaseLogin.constring))
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

        public void deposit(int accountnumber, decimal transaction)
        {
            // Get account balance
            SqlConnection sqlConn = new SqlConnection(DatabaseLogin.constring);
            SqlCommand cmd = new SqlCommand("Select Balance from Account where PK_Accountnumber = " + accountnumber + " ", sqlConn);
            sqlConn.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            sqlConn.Close();

            decimal currBalance = decimal.Parse(ds.Tables[0].Rows[0][0].ToString());
            Console.WriteLine("Current balacne" + currBalance);

            // Make balance calculation
            currBalance = currBalance + transaction;

            // Update balance 
            var sql = "UPDATE Account SET Balance = @Balance where PK_Accountnumber = @PK_Accountnumber";
            try
            {
                using (var connection = new SqlConnection(DatabaseLogin.constring))
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
                MessageBox.Show($"Failed to deposit. Error message: {e.Message}");
            }
        }

    }

}
