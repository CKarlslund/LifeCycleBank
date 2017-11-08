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
        private IBank _bank;
        
        public CreateFileData(IBank bank)
        {
            _bank = bank;
        }

        public string GetPath(string fileName)
        {
            var path = @"bankdata\";

            return Path.Combine(path, fileName);
        }

        public void CreateFile(IWriter writer)
        {  
                writer.WriteLine(_bank.Customers.Count.ToString());
                foreach (var c in _bank.Customers)
                {
                    var customerInfo = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}", c.Id.ToString(), c.OrganizationNumber, c.CompanyName,
                        c.Address, c.City, c.Region, c.PostalCode, c.Country, c.PhoneNumber).ToString();
                    writer.WriteLine(customerInfo);
                }
                writer.WriteLine(_bank.Accounts.Count.ToString());
                foreach (var a in _bank.Accounts)
                {
                    var accountInfo = string.Format("{0};{1};{2}", a.Id.ToString(), a.Owner.Id.ToString(), a.Balance.ToString()).ToString();
                    writer.WriteLine(accountInfo);
                }
        
            writer.Dispose();
        }

    }

}
