using LifeCycleBank.Models;
using LifeCycleBank.services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LifeCycleBank
{
    class ReadFileData
    {
        private static List<Account> accounts = new List<Account>();
        private static List<Customer> customers = new List<Customer>();
        public  static void ReadFileFromBankData()
        {
            var number = 0;

            string[] lines = System.IO.File.ReadAllLines(GetLatestFile.GetPathToLatestFile());

            for (int i = 0; i < lines.Length; i++)
            {
                if (Regex.IsMatch(lines[i], "^[0-9]*$"))
                {
                    number = Convert.ToInt32(lines[i]);
                }
                if (Array.IndexOf(lines, i) < number)
                {
                    var splitLine = lines[i].Split(";");
                  
                        if(splitLine.Length > 3 && !(splitLine.Length < 3))
                        {
                            //new Customer
                            var customer = new Customer();
                            customer.Id = Convert.ToInt32(splitLine[0]);
                            customer.OrganizationNumber = splitLine[1];
                            customer.CompanyName = splitLine[2];
                            customer.Address = splitLine[3];
                            customer.City = splitLine[4];
                            customer.Region = splitLine[5];
                            customer.PostalCode = splitLine[6];
                            customer.Country = splitLine[7];
                            customer.PhoneNumber = splitLine[8];

                            customers.Add(customer);
                        }
                        else if(splitLine.Length == 3)
                        {
                        //new Account
                        var account = new Account();
                        account.Id = Convert.ToInt32(splitLine[0]);
                        account.Owner = customers.FirstOrDefault(x=>x.Id == Convert.ToInt32(splitLine[1]));
                        account.Balance = Convert.ToDecimal(splitLine[2].Replace(".", ","));

                        accounts.Add(account);
                    }
                  
                 }
            }
        }

        public static List<Customer> GetAllCustomers()
        {
            return customers;
        }

        public static List<Account> GetAllAccounts()
        {
            return accounts;
        }
       
    }
}
