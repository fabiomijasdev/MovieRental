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
                    .Include(c => c.Customer)
                    .Include(m => m.Movie)
                    .Where(c => c.Customer.Name.Contains(customerName))
                    .AsNoTracking()
                    .ToListAsync();
    }

    public async Task<Rental> AddAsync(Rental rental)
    {
        await _movieRentalDb.Rentals.AddAsync(rental);
        await _movieRentalDb.SaveChangesAsync();
        return rental;
    }
}
