using System.Collections.Generic;
using LifeCycleBank.Interfaces;
using System.Linq;
using LifeCycleBank.Models;
using System;

namespace LifeCycleBank.Tests
{
    class MockBank : IBank
    {
        public MockBank()
        {
            GetBankData();
        }

        public int Id { get; set; }
        public List<IAccount> Accounts { get; set; }
        public List<ICustomer> Customers { get; set; }

        public void GetBankData()
        {
            var customer1 = new Customer() {
                Id = 1001,
                OrganizationNumber = "559268 - 7528",
                CompanyName = "Berglunds snabbköp",
                Address = "Berguvsvägen  8",
                City = "Luleå",
                Region = null,
                PostalCode = "S - 958 22",
                Country = "Sweden",
                PhoneNumber = "0921 - 12 34 65"
                };
            var customer2 = new Customer() { Id = 1002, CompanyName = "Bengans Import AB", City = "Malmö"};
            var customer3 = new Customer() { Id = 1003, CompanyName = "Sveas Mode", City = "Luleå"};

            var customers = new List<ICustomer>() {customer1, customer2, customer3};

            var accounts = new List<IAccount>()
            {
                new Account(){Id = 13001, Owner = customer1, Balance = 100},
                new Account(){Id = 13002, Owner = customer1, Balance = 200},
                new Account(){Id = 13003, Owner = customer2, Balance = 300},
                new Account(){Id = 13004, Owner = customer3, Balance = 400}
            };

            Accounts = accounts;
            Customers = customers;
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
            if (!string.IsNullOrEmpty(organizationNumber) &&
                !string.IsNullOrEmpty(companyName) &&
                !string.IsNullOrEmpty(address) &&
                !string.IsNullOrEmpty(postalCode) &&
                !string.IsNullOrEmpty(city))
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
            else
                return "false";
        }

        public string CreateAccount(ICustomer customerId, int balance)
        {
            try
            {
                Accounts.Add(new Account { Id = Accounts.Max(x => x.Id) + 1, Owner = customerId, Balance = balance });
                return ("true");
            }
            catch (Exception)
            {
                return ("false");
            }
        }

     public string DeleteAccount(int accountId)
        {
            try
            {
                Accounts.Remove(Accounts.FirstOrDefault(x => x.Id == accountId));
                return ("true");
            }
            catch (Exception)
            {
                return ("false");
            }
        }

        public string DeleteCustomer(int customerId)
        {
            try
            {
                Customers.Remove(Customers.FirstOrDefault(x => x.Id == customerId));
                return ("true");
            }
            catch (Exception)
            {
                return ("false");
            }
        }
    }
}
