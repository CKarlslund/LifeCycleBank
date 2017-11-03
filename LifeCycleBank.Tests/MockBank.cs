﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using LifeCycleBank.Interfaces;
using LifeCycleBank.Models;

namespace LifeCycleBank.Tests
{
    class MockBank : IBank
    {
        public int Id { get; set; }
        public List<IAccount> Accounts { get; set; }
        public List<ICustomer> Customers { get; set; }

        public void GetBankData()
        {
            var customer1 = new Customer() {Id = 1001,};
            var customer2 = new Customer() { Id = 1002, };
            var customer3 = new Customer() { Id = 1002, };

            var customers = new List<ICustomer>() {customer1, customer2, customer3};

            var accounts = new List<IAccount>()
            {
                new Account(){Id = 13001, Owner = customer1, Balance = 100},
                new Account(){Id = 13002, Owner = customer1, Balance = 200},
                new Account(){Id = 13003, Owner = customer2, Balance = 300},
                new Account(){Id = 13004, Owner = customer3, Balance = 400}
            };

            Accounts = accounts;
            Customers = customers;
        }
    }
}