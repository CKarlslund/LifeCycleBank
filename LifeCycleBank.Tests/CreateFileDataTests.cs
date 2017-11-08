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
            var createFileData = new CreateFileData(bank);
            createFileData.CreateFile(writer);

            Assert.Equal(output.Count, 9);
        }

        [Fact]
        public void WritesCorrectFormat()
        {
            var bank = new MockBank();
            var output = new List<string>();
            var writer = new MockWriter(output);
            var createFileData = new CreateFileData(bank);
            createFileData.CreateFile(writer);

            Assert.Equal(output[0], "3");
            Assert.Equal(output[1], "1001;559268 - 7528;Berglunds snabbköp;Berguvsvägen  8;Luleå;;S - 958 22;Sweden;0921 - 12 34 65");
            Assert.Equal(output[4], "4");
            Assert.Equal(output[5], "13001;1001;100");
        }
    }
}

      