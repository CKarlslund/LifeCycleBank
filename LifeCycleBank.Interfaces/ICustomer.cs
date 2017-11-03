namespace LifeCycleBank.Interfaces
{
    public interface ICustomer
    {
        int Id { get; set; }
        string OrganizationNumber { get; set; }
        string CompanyName { get; set; }
        string Address { get; set; }
        string PostalCode { get; set; }
        string City { get; set; }
        string Region { get; set; }
        string Country { get; set; }
        string PhoneNumber { get; set; }
    }
}