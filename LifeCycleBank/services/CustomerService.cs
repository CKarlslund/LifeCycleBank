using LifeCycleBank.Interfaces;
using LifeCycleBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeCycleBank.services
{
    public class CustomerService
    {
        public static List<ICustomer> SearchCustomer(IBank bank,string searchWord)
        {
            var customers = bank.Customers.Where(x => x.CompanyName == searchWord || x.City == searchWord).ToList();

            return customers;
        }

        public static ICustomer GetCustomer(IBank bank, int customerNumber)
        {
            var customer = bank.Customers.SingleOrDefault(x => x.Id == customerNumber);

            return customer;
        }

        public static List<IAccount> GetCustomerAccounts(IBank bank,int customerID)
        {
            var customerAccounts = bank.Accounts.Where(x => x.Owner.Id == customerID).ToList();

            return customerAccounts;
        }
    }
}
