using System;
using System.Collections.Generic;
using System.Text;

namespace LifeCycleBank
{
    public class AccountBalanceException : Exception
    {
        public AccountBalanceException()
        {
            
        }

        public AccountBalanceException(string message) : base(message)
        {
            
        }

        public AccountBalanceException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}
