using System;
using System.Collections.Generic;
using System.Text;

namespace LifeCycleBank.Models
{
    class Bank
    {
        public int Id { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Transaction> Type { get; set; }
    }
}
