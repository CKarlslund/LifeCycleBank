using LifeCycleBank.services;
using System;
using System.IO;
using Xunit;

namespace LifeCycleBank.Tests
{
    public class BankDataTests
    {
        [Fact]
        public void Read_File_Data()
        {
           
            var path = GetLatestFile.GetPathToLatestFile();
            Assert.Equal("", path);
        }
    }
}
