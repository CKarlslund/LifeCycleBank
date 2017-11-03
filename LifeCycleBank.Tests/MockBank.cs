using System.Collections.Generic;
using LifeCycleBank.Interfaces;
using System.Linq;
using LifeCycleBank.Models;

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
            var customer1 = new Customer() {Id = 1001,};
            var customer2 = new Customer() { Id = 1002, };
            var customer3 = new Customer() { Id = 1002, };

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
    }
}
