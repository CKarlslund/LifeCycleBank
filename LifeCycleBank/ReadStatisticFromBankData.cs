using System;
using System.Collections.Generic;
using System.Text;

namespace LifeCycleBank
{
    class ReadStatisticFromBankData
    {
        public void ReadStatistic()
        {

            var accounts = ReadFileData.GetAllAccounts();
            var numberOfCustomers = ReadFileData.GetAllCustomers().Count;
            var numberOfAccounts = accounts.Count;
            var balance = 0M;

            foreach (var account in accounts)
            {
                balance += account.Balance;
            }
            

        }
    }
}
