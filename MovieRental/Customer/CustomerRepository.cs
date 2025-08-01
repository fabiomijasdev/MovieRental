using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Customer;

public class CustomerRepository : ICustomerRepository
{
    private readonly MovieRentalDbContext _movieRentalDb;

    public CustomerRepository(MovieRentalDbContext movieRentalDbContext)
    {
        _movieRentalDb = movieRentalDbContext;
    }
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _movieRentalDb.Customer
                    .AsNoTracking()
                    .ToListAsync();
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        await _movieRentalDb.Customer.AddAsync(customer);
        await _movieRentalDb.SaveChangesAsync();
        return customer;
    }
}
