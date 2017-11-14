using LifeCycleBank.Interfaces;
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
    }
}
