namespace LifeCycleBank.Interfaces
{
    public interface IAccount
    {
        int Id { get; set; }
        ICustomer Owner { get; set; }
        decimal Balance { get; set; }
    }
}