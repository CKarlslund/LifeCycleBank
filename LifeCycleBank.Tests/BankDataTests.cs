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
    }
}
