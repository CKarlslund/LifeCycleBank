using LifeCycleBank.Interfaces;
using LifeCycleBank.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Withdrawal_Amount_Must_Be_Larger_Than_0()
        {
            var account = _bank.Accounts.FirstOrDefault(a => a.Id == 13003);

            try
            {
                _bank.CreateWithdrawal(account, -700.00M);
                _bank.CreateDeposit(account, 0M);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Deposit_Amount_Must_Be_Larger_Than_0()
        {
            var account = _bank.Accounts.FirstOrDefault(a => a.Id == 13003);

            try
            {
                _bank.CreateDeposit(account, -700.00M);
                _bank.CreateDeposit(account, 0M);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Transaction_Amount_Must_Be_Larger_Than_0()
        {
            var fromAccount = _bank.Accounts.FirstOrDefault(a => a.Id == 13003);
            var toAccount = _bank.Accounts.FirstOrDefault(a => a.Id == 13004);

            try
            {
                _bank.CreateTransaction(fromAccount, toAccount, -200);
                _bank.CreateTransaction(fromAccount, toAccount, 0);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Can_Create_Withdrawal()
        {
            var account = _bank.Accounts.FirstOrDefault(a => a.Id == 13003);

            _bank.CreateWithdrawal(account, 200.00M);

            var result = _bank.Accounts.FirstOrDefault(a => a.Id == account.Id);

            Assert.Equal(100.00M, result.Balance);
        }

        [Fact]
        public void Cannot_Withdraw_More_Than_Balance()
        {
            var account = _bank.Accounts.FirstOrDefault(a => a.Id == 13003);

            Assert.Throws<AccountBalanceException>(() => _bank.CreateWithdrawal(account, 500.00M));
        }

        [Fact]
        public void Can_Create_Transaction()
        {
            var fromAccount = _bank.Accounts.FirstOrDefault(a => a.Id == 13003);
            var toAccount = _bank.Accounts.FirstOrDefault(a => a.Id == 13004);

            _bank.CreateTransaction(fromAccount, toAccount, 200);

            var fromAccountResult = _bank.Accounts.FirstOrDefault(a => a.Id == fromAccount.Id);
            var toAccountResult = _bank.Accounts.FirstOrDefault(a => a.Id == toAccount.Id);

            Assert.Equal(100, fromAccountResult.Balance);
            Assert.Equal(600, toAccountResult.Balance);
        }

        [Fact]
        public void Cannot_Transact_More_Than_Balance()
        {
            var fromAccount = _bank.Accounts.FirstOrDefault(a => a.Id == 13003);
            var toAccount = _bank.Accounts.FirstOrDefault(a => a.Id == 13004);

            Assert.Throws<AccountBalanceException>(() => _bank.CreateTransaction(fromAccount, toAccount, 400));
        }

        [Fact]

        public void Can_Create_Customer()
        {
            var customer = _bank.CreateCustomer("12345", "Nackademin", "Tomtebodavägen 10", "12345", "Stockholm", "Sweden", "region", "0723457689");
             Assert.Equal("true", customer);
        }
        
        [Fact]
        public void Can_Delete_Customer()
        {
            var customer = _bank.DeleteCustomer(1092);

            Assert.Equal("true", customer);
        }

        [Fact]
        public void Can_Create_Account()
        {
            var customer = _bank.Customers.FirstOrDefault(a => a.Id == 1092);
            var account = _bank.CreateAccount(customer, 1000);
          
           Assert.Equal("true", account);
        }
      
        [Fact]
        public void Can_Delete_Account()
        {
            var account = _bank.DeleteAccount(13013);

            Assert.Equal("true", account);
        }
    }
}
