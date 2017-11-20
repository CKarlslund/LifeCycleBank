using LifeCycleBank.Interfaces;
using LifeCycleBank.services;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LifeCycleBank.Tests
{
    class MockWriter : IWriter
    {
        private List<string> _output;

        public MockWriter(List<string> output)
        {
            _output = output;
        }
        public void Dispose()
        {

        }
        
        public void WriteLine(string value)
        {
            _output.Add(value);
        }
    }
}
