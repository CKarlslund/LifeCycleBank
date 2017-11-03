using LifeCycleBank.Interfaces;
using LifeCycleBank.services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LifeCycleBank.Tests
{
    public class CreateFileDataTests
    {
        private IBank _bank;

        public CreateFileDataTests()
        {
            _bank = new MockBank();
        }

        [Fact]
        public void CanCreateFile()
        {
            CreateFileData.CreateFile(_bank);
        }
    }
}
