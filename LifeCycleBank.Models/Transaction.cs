using System;
using System.Collections.Generic;
using System.Text;

namespace LifeCycleBank.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public Customer FromCustomer { get; set; }
        public Customer ToCustomer { get; set; }
        public decimal TransactionAmount { get; set; }
    }
}
