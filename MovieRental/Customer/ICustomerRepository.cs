namespace MovieRental.Customer;

public interface ICustomerRepository
{
    Task<Customer> AddAsync(Customer customer);
    Task<IEnumerable<Customer>> GetAllAsync();
}
