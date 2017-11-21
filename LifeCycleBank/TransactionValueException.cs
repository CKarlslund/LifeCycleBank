using System;
using System.Collections.Generic;
using System.Text;

namespace LifeCycleBank
{
    public class TransactionValueException : Exception
    {
        public TransactionValueException()
        {
            
        }

        public TransactionValueException(string message) : base(message)
        {
            
        }

        public TransactionValueException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}
