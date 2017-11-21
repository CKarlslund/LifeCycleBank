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
        public void SearchCustomerTest()
        {
            var bank = new MockBank();
            var customers = CustomerService.SearchCustomer(bank, "Luleå");

            Assert.Equal(2, customers.Count);
        }

        [Fact]
        public void Can_Enter_Partial_SerchTest()
        {
            var bank = new MockBank();
            var customers = CustomerService.SearchCustomer(bank, "Berg ");

            Assert.Equal(1, customers.Count);
        }
    }
}
