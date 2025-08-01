using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Rental
{
    public class RentalFeatures : IRentalFeatures
    {
        private readonly MovieRentalDbContext _movieRentalDb;
        public RentalFeatures(MovieRentalDbContext movieRentalDb)
        {
            _movieRentalDb = movieRentalDb;
        }

        //Explanations:
        //Synchronous
        //Executes step by step, locking the thread.
        //Asynchronous
        //Releases the thread while waiting for I/O(such as database access).
        public async Task<Rental> SaveAsync(Rental rental)
        {
            await _movieRentalDb.Rentals.AddAsync(rental);
            await _movieRentalDb.SaveChangesAsync();
            return rental;
        }

        //TODO: finish this method and create an endpoint for it
        public async Task<IEnumerable<Rental>> GetRentalsByCustomerNameAsync(string customerName)
        {
            return await _movieRentalDb.Rentals
                        .Include(r => r.Customer) // Ensure Customer is loaded
                        .Where(r => r.Customer.Name.Contains(customerName)) // Case-sensitive, partial match
                        .ToListAsync();
        }

    }
}
