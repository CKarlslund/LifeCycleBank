using LifeCycleBank.services;
using System;
using System.IO;
using Xunit;

namespace LifeCycleBank.Tests
{
    public class BankDataTests
    {
        [Fact]
        public void Get_Date_From_FileName_Test()
        {
            var fileDate = GetLatestFile.GetDateFromFileName("20171019-1243.txt");
            var date = new DateTime(2017,10,19,12,43,0);
            Assert.Equal(date, fileDate);
        }

        [Fact]
        public void Read_File()
        {
            var mockFile = new MockFile();
            ReadFileData.ReadFile(mockFile.GetMockFile());
            var countAccounts = ReadFileData.GetAllAccounts().Count;
            Assert.Equal(5, countAccounts);
        }
    }
}
