using LifeCycleBank.Interfaces;
using LifeCycleBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LifeCycleBank
{
    public class Bank : IBank
    {
        private static Bank _instance;

        public static Bank Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Bank();
                return _instance;
            }
        }

        protected internal Bank()
        {
            GetBankData();
        }
        public int Id { get; set; }
        public List<IAccount> Accounts { get; set; }
        public List<ICustomer> Customers { get; set; }

        public void GetBankData()
        {
            Accounts = ReadFileData.GetAllAccounts();
            Customers = ReadFileData.GetAllCustomers();
        }

        public void CreateDeposit(IAccount toAccount, decimal amount)
        {
            var account = Accounts.FirstOrDefault(a => a.Id == toAccount.Id);

            account.Balance += amount;
        }

        public void CreateWithdrawal(IAccount fromAccount, decimal amount)
        {
            var account = Accounts.FirstOrDefault(a => a.Id == fromAccount.Id);

            if (amount <= account.Balance)
            {
                account.Balance = account.Balance - amount;
            }
            else
            {
                throw new AccountBalanceException("The targeted account does not have enough money!");
            }
        }

        public void CreateTransaction(IAccount fromAccount, IAccount toAccount, decimal amount)
        {
            var creditAccount = Accounts.FirstOrDefault(a => a.Id == fromAccount.Id);
            var debitAccount = Accounts.FirstOrDefault(a => a.Id == toAccount.Id);


            if (amount <= creditAccount.Balance)
            {
                creditAccount.Balance = creditAccount.Balance - amount;
                debitAccount.Balance += amount;
            }
            else
            {
                throw new AccountBalanceException("The specified amount was bigger than the available sum on the credit account. Could not continue.");
            }
        }

        public string CreateCustomer(string organizationNumber, string companyName, string address, string postalCode, string city, string country, string region, string phoneNumber)
        {
            try
            {
                var customer = new Customer
                {
                    Id = Customers.Max(x => x.Id) + 1,
                    OrganizationNumber = organizationNumber,
                    CompanyName = companyName,
                    Address = address,
                    PostalCode = postalCode,
                    City = city,
                    Country = country,
                    Region = region,
                    PhoneNumber = phoneNumber
                };
                Customers.Add(customer);
                Accounts.Add(new Account { Id = Accounts.Max(x => x.Id) + 1, Owner = customer, Balance = 0 });
                return "true";
            }
            catch (Exception)
            {
                return "false";
            }
        }
    }
}
