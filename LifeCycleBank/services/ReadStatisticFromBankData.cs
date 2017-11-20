using System;
using System.Collections.Generic;
using System.Text;

namespace LifeCycleBank
{
    public class ReadStatisticFromBankData
    {
        public static Dictionary<string, string> GetStatistics()
        {
            var statistics = new Dictionary<string, string>();
            var accounts = ReadFileData.GetAllAccounts();
            var customers = ReadFileData.GetAllCustomers();
            var balance = 0M;

            foreach (var account in accounts)
            {
                balance += account.Balance;
            }

            statistics.Add("numberOfAccounts", accounts.Count.ToString());
            statistics.Add("numberOfCustomers", customers.Count.ToString());
            statistics.Add("totalBalance", balance.ToString());

            return statistics;
        }
    }
}
