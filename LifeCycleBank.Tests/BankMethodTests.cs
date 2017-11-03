using LifeCycleBank.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace LifeCycleBank.Tests
{
    public class BankTests
    {
        private IBank _bank;

        public BankTests()
        {
            _bank = new MockBank();
        }

        [Fact]
        public void Can_Create_Deposit()
        {          
            var account = _bank.Accounts.FirstOrDefault(a => a.Id == 13003);

            _bank.CreateDeposit(account, 700.00M);

            var result = _bank.Accounts.FirstOrDefault(a => a.Id == account.Id);

            Assert.Equal(1000.00M, result.Balance);
        }

        [Fact]
        public void Can_Create_Withdrawal()
        {
            var account = _bank.Accounts.FirstOrDefault(a => a.Id == 13003);

            _bank.CreateDeposit(account, 700.00M);

            var result = _bank.Accounts.FirstOrDefault(a => a.Id == account.Id);

            Assert.Equal(1000.00M, result.Balance);
        }

        [Fact]
        public void Cannot_Withdraw_More_Than_Balance()
        {
            //TODO tests
        }

        [Fact]
        public void Can_Create_Transaction()
        {
            //TODO tests
        }

        [Fact]
        public void Cannot_Transact_More_Than_Balance()
        {
            //TODO tests
        }
    }
}
