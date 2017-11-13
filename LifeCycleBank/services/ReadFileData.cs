using LifeCycleBank.Interfaces;
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
        private static List<IAccount> accounts = new List<IAccount>();
        private static List<ICustomer> customers = new List<ICustomer>();
        private static decimal totalBalance = 0M;

        public static void ReadFileFromBankData()
        {

            string[] lines = System.IO.File.ReadAllLines(GetLatestFile.GetPathToLatestFile());
            ReadFile(lines);
        }
        public  static void ReadFile(string [] lines)
        {
            var number = 0;

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
                        var customer = new Customer
                        {
                            Id = Convert.ToInt32(splitLine[0]),
                            OrganizationNumber = splitLine[1],
                            CompanyName = splitLine[2],
                            Address = splitLine[3],
                            City = splitLine[4],
                            Region = splitLine[5],
                            PostalCode = splitLine[6],
                            Country = splitLine[7],
                            PhoneNumber = splitLine[8]
                        };

                        customers.Add(customer);
                        }
                        else if(splitLine.Length == 3)
                        {
                        //new Account
                        var account = new Account
                        {
                            Id = Convert.ToInt32(splitLine[0]),
                            Owner = customers.FirstOrDefault(x => x.Id == Convert.ToInt32(splitLine[1])),
                            Balance = Convert.ToDecimal(splitLine[2].Replace(".", ","))
                        };
                        totalBalance += account.Balance;
                        accounts.Add(account);
                    }
                  
                 }
            }
        }

     
        public static List<ICustomer> GetAllCustomers()
        {
            return customers;
        }

        public static List<IAccount> GetAllAccounts()
        {
            return accounts;
        }

        public static decimal GetTotalBalance()
        {
            return totalBalance;
        }
       
    }
}
