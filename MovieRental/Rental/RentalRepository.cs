using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Rental;

public class RentalRepository : IRentalRepository
{
    private readonly MovieRentalDbContext _movieRentalDb;
    public RentalRepository(MovieRentalDbContext movieRentalDbContext)
    {
        _movieRentalDb = movieRentalDbContext;
    }

    public async Task<IEnumerable<Rental>> GetRentalsByCustomerNameAsync(string customerName)
    {
        return await _movieRentalDb.Rentals
                    .Include(r => r.Customer) // Ensure Customer is loaded
                    .Where(r => r.Customer.Name.Contains(customerName)) // Case-sensitive, partial match
                    .ToListAsync();
    }

    public async Task<Rental> SaveAsync(Rental rental)
    {
        await _movieRentalDb.Rentals.AddAsync(rental);
        await _movieRentalDb.SaveChangesAsync();
        return rental;
    }
}
