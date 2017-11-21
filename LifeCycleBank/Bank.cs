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
        public decimal TotalBalance { get; set; }

        public void GetBankData()
        {
            Accounts = ReadFileData.GetAllAccounts();
            Customers = ReadFileData.GetAllCustomers();
            TotalBalance = ReadFileData.GetTotalBalance();
        }

        public void CreateDeposit(IAccount toAccount, decimal amount)
        {
            if (amount > 0)
            {
                var account = Accounts.FirstOrDefault(a => a.Id == toAccount.Id);

                account.Balance += amount;
            }
            else
            {
                throw new TransactionValueException("Det angivna värdet är inte giltigt för en insättning.");
            }
        }

        public void CreateWithdrawal(IAccount fromAccount, decimal amount)
        {
            var account = Accounts.FirstOrDefault(a => a.Id == fromAccount.Id);

            if (amount > 0)
            {
                if (amount <= account.Balance)
                {
                    account.Balance = account.Balance - amount;
                }
                else
                {
                    throw new AccountBalanceException("Täckning saknas");
                }
            }
            else
            {
                throw new TransactionValueException("Det angivna värdet är inte giltigt för uttag.");
            }
        }

        public void CreateTransaction(IAccount fromAccount, IAccount toAccount, decimal amount)
        {
            var creditAccount = Accounts.FirstOrDefault(a => a.Id == fromAccount.Id);
            var debitAccount = Accounts.FirstOrDefault(a => a.Id == toAccount.Id);

            if (amount > 0)
            {
                if (amount <= creditAccount.Balance)
                {
                    creditAccount.Balance = creditAccount.Balance - amount;
                    debitAccount.Balance += amount;
                }
                else
                {
                    throw new AccountBalanceException("Det angivna värdet är större än täckningen på kontot. Transaktionen avbruten.");
                }
            }
            else
            {
                throw new TransactionValueException("Det angivna värdet är inte giltigt för en transaktion.");
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

        public string CreateAccount(ICustomer customerId, decimal balance)
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

        public bool ValidateDeleteCustomer(int customerId, List<IAccount> accounts)
        {
            return accounts.Sum(x => x.Balance) == 0;
        }


        internal bool ValidateDeleteCustomer(int accountId, Bank bank)
        {

            var account = bank.Accounts.Find(x => x.Id == accountId);
            return account != null && account.Balance == 0;
        }
    }
}
