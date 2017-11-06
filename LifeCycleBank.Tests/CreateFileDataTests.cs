using LifeCycleBank.Interfaces;
using LifeCycleBank.services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.IO;

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
        public void WritesCorrectNumberOfLines()
        {
            var bank = new MockBank();
            var output = new List<string>();
            var writer = new MockWriter(output);
            var createFileData = new CreateFileData(bank, writer);
            createFileData.CreateFile();

            Assert.Equal(output.Count, 9);
        }
    }
}

      