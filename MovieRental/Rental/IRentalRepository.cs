namespace MovieRental.Rental;

public interface IRentalRepository
{
    Task<Rental> AddAsync(Rental rental);
    Task<IEnumerable<Rental>> GetRentalsByCustomerNameAsync(string customerName);
}
