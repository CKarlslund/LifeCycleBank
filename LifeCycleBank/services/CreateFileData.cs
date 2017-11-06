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
        private IWriter _writer;

        public CreateFileData(IBank bank, IWriter writer)
        {
            _bank = bank;
            _writer = writer;
        }

        public void CreateFile()
        {  
                _writer.WriteLine(_bank.Customers.Count.ToString());
                foreach (var c in _bank.Customers)
                {
                    var customerInfo = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}", c.Id.ToString(), c.OrganizationNumber, c.CompanyName,
                        c.Address, c.City, c.Region, c.PostalCode, c.Country, c.PhoneNumber).ToString();
                    _writer.WriteLine(customerInfo);
                }
                _writer.WriteLine(_bank.Accounts.Count.ToString());
                foreach (var a in _bank.Accounts)
                {
                    var accountInfo = string.Format("{0};{1};{2}", a.Id.ToString(), a.Owner.Id.ToString(), a.Balance.ToString()).ToString();
                    _writer.WriteLine(accountInfo);
                }
        
            _writer.Dispose();
        }

    }

}
