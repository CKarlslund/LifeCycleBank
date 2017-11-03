using System;
using LifeCycleBank.Interfaces;

namespace LifeCycleBank.Models
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        public string OrganizationNumber { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }
}
