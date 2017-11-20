using LifeCycleBank.Interfaces;
using LifeCycleBank.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace LifeCycleBank.services
{
    public class CreateFileData
    {
        public static string GetPath(string fileName)
        {
            var path = @"bankdata\";

            return Path.Combine(path, fileName);
        }

        public static void CreateFile(IBank bank, IWriter writer)
        {  
                writer.WriteLine(bank.Customers.Count.ToString());
                foreach (var c in bank.Customers)
                {
                    var customerInfo = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}", c.Id.ToString(CultureInfo.InvariantCulture), c.OrganizationNumber, c.CompanyName,
                        c.Address, c.City, c.Region, c.PostalCode, c.Country, c.PhoneNumber).ToString(CultureInfo.InvariantCulture);
                    writer.WriteLine(customerInfo);
                }
                writer.WriteLine(bank.Accounts.Count.ToString());
                foreach (var a in bank.Accounts)
                {
                    var accountInfo = string.Format("{0};{1};{2}", a.Id.ToString(CultureInfo.InvariantCulture), a.Owner.Id.ToString(CultureInfo.InvariantCulture), a.Balance.ToString(CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);
                    writer.WriteLine(accountInfo);
                }
        
            writer.Dispose();
        }

    }

}
