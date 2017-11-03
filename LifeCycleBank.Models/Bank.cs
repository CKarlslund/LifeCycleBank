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

        public int Id { get; set; }
        public List<IAccount> Accounts { get; set; }
        public List<ICustomer> Customers { get; set; }

        public void GetBankData()
        {
            //Read all the bank data
        }
    }
}
