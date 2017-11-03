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
    }
}
