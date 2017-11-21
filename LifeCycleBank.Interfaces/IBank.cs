using System;
using System.Collections.Generic;
using System.Transactions;

namespace LifeCycleBank.Interfaces
{
    public interface IBank
    {
        int Id { get; set; }
        List<IAccount> Accounts { get; set; }
        List<ICustomer> Customers { get; set; }

        void GetBankData();
        void CreateDeposit(IAccount toAccount, decimal amount);
        void CreateWithdrawal(IAccount fromAaccount, decimal amount);
        void CreateTransaction(IAccount fromAccount, IAccount toAccount, decimal amount);
        string CreateCustomer(string organizationNumber, string companyName, string address, string postalCode, string city, string country, string region, string phoneNumber);
        string CreateAccount(ICustomer customerId, int balance);
    }
}
