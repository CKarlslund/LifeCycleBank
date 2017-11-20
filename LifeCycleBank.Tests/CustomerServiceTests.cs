using LifeCycleBank.Interfaces;
using LifeCycleBank.Models;
using LifeCycleBank.services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LifeCycleBank.Tests
{
    public class CustomerServiceTests
    {
        private IBank _bank;

        public CustomerServiceTests()
        {
            _bank = new MockBank();
        }

        [Fact]
        public void GetCustomerTest()
        {
            var bank = new MockBank();
            var customer = CustomerService.GetCustomer(bank, 1001);

            Assert.Equal("Sweden", customer.Country);
        }

        [Fact]
        public void GetCustomerAccountsTest()
        {
            var bank = new MockBank();
            var accounts = CustomerService.GetCustomerAccounts(bank, 1001);

            Assert.Equal(2, accounts.Count);
        }

        [Fact]
        public void SercCustomerTest()
        {
            var bank = new MockBank();
            var customers = CustomerService.SearchCustomer(bank, "luleå");

            Assert.Equal(2, customers.Count);
        }
    }
}
