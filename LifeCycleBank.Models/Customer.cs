using System;

namespace LifeCycleBank.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerNumber { get; set; }
        public string OrganizationNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
