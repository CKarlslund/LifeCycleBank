using System;
using System.Collections.Generic;
using System.Text;
using LifeCycleBank.Interfaces;

namespace LifeCycleBank.Models
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
            throw new NotImplementedException();
        }

        public void CreateWithdrawal(IAccount fromAaccount, decimal amount)
        {
            throw new NotImplementedException();
        }

        public void CreateTransaction(IAccount fromAccount, IAccount toAccount, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
