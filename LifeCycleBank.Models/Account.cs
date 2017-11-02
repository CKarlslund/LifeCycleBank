using System;
using System.Collections.Generic;
using System.Text;

namespace LifeCycleBank.Models
{
    public class Account
    {
        public int Id { get; set; }
        public Customer Owner { get; set; }
        public decimal Balance { get; set; }
    }
}
