using System;
using System.Collections.Generic;
using System.Text;

namespace LifeCycleBank.Interfaces
{
    public interface IWriter : IDisposable
    {
        void WriteLine(string value);
    }
}
