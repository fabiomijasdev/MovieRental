namespace MovieRental.Customer
{
    public interface ICustomerFeatures
    {
        Task<Customer> AddAsync(Customer customer);
        Task<IEnumerable<Customer>> GetAllAsync();
    }
}
