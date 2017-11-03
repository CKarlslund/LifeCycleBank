using LifeCycleBank.Interfaces;
using LifeCycleBank.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LifeCycleBank.services
{
    public class CreateFileData
    {
        public static string CreateFile(Bank bank)
        {
            string fileName = DateTime.Now.ToString("yyyyMMdd-HHmm") + ".txt";
            var path = @"bankdata\";
            string pathString = Path.Combine(path, fileName);

            using (StreamWriter sw = new StreamWriter(pathString, true))
            {
                sw.WriteLine(bank.Customers.Count);
                foreach (var c in bank.Customers)
                {
                    sw.WriteLine($"{0};{1};{2};{3};{4};{5};{6};{7};{8}", c.Id.ToString(), c.OrganizationNumber, c.CompanyName,
                        c.Address, c.City, c.Region, c.PostalCode, c.Country, c.PhoneNumber);
                }
                sw.WriteLine(bank.Accounts.Count);
                foreach (var a in bank.Accounts)
                {
                    sw.WriteLine($"{0};{1};{2}", a.Id.ToString(), a.Owner.Id.ToString(), a.Balance.ToString());
                }
            }

            return fileName;
        }
    }
}
