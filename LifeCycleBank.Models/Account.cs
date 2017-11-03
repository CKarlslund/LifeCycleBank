using System;
using System.Collections.Generic;
using System.Text;
using LifeCycleBank.Interfaces;

namespace LifeCycleBank.Models
{
    public class Account : IAccount
    {
        public int Id { get; set; }
        public ICustomer Owner { get; set; }
        public decimal Balance { get; set; }
    }
}
