namespace MovieRental.Customer;

public class CustomerFeatures : ICustomerFeatures
{

    private readonly ICustomerRepository _customerRepository;

    public CustomerFeatures(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _customerRepository.GetAllAsync();
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        await _customerRepository.AddAsync(customer);
        return customer;
    }
}
